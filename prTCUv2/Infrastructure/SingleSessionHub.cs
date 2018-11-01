using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
//using prTCUv2.Services;
using System.Web.Security;
using System.Runtime.Caching;

namespace prTCUv2.Infrastructure
{
    public class User
    {
        public string Name { get; set; }
        public string IPAdress { get; set; }
        public string SessionID { get; set; }
        public string Browser { get; set; }
        public HashSet<string> ConnectionIds { get; set; }
    }

    [Authorize]
    public class SingleSessionHub : Hub
    {
        //private LoginService oLogin = new LoginService();
        private CacheItemPolicy policy = new CacheItemPolicy();
        private static MemoryCache myCache = new MemoryCache("UserConnIDs");

        public override Task OnConnected()
        {
            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;
            string IP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            string SessionID = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value;
            string Browser = HttpContext.Current.Request.Browser.Browser;

            policy.SlidingExpiration = TimeSpan.FromMinutes(10);
            User CachedUser = (User)myCache.Get(userName);

            var user = new User
            {
                Name = userName,
                IPAdress = IP,
                SessionID = SessionID,
                Browser = Browser,
                ConnectionIds = new HashSet<string>()
            };

            if (CachedUser != null)
            {
                if (CachedUser.SessionID == SessionID)
                {
                    lock (CachedUser.ConnectionIds)
                    {
                        CachedUser.ConnectionIds.Add(connectionId);
                        myCache.Set(userName, CachedUser, policy);
                        Clients.All.UserClientsOnline(CachedUser.ConnectionIds.Count);
                    }
                }
                else
                {
                    lock (user.ConnectionIds)
                    {
                        Clients.Client(connectionId).AlertMessage("You have authenticated from a new device. For security reasons we closed your previous session in " + CachedUser.Browser + " with the IP: " + CachedUser.IPAdress + ". Remember that you can only be authenticated in one device at once.");
                        user.ConnectionIds.Add(connectionId);
                        //oLogin.UserConnected(Context.User.Identity.Name, "webAdmin");
                        myCache.Set(userName, user, policy);
                        Clients.Client(CachedUser.ConnectionIds.First()).UserClientsOnline(0);
                    }
                }
            }
            else
            {
                lock (user.ConnectionIds)
                {
                    user.ConnectionIds.Add(connectionId);
                    //oLogin.UserConnected(Context.User.Identity.Name, "webAdmin");
                    myCache.Add(userName, user, policy);
                }
            }

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            if (stopCalled)
            {
                string userName = Context.User.Identity.Name;
                string connectionId = Context.ConnectionId;

                User user = (User)myCache.Get(userName);

                if (user != null)
                {
                    lock (user.ConnectionIds)
                    {
                        user.ConnectionIds.RemoveWhere(cid => cid.Equals(connectionId));

                        if (!user.ConnectionIds.Any())
                        {
                            myCache.Remove(userName);
                            //oLogin.UserDisconnected(userName, "webAdmin");
                        }
                    }
                }
            }

            return base.OnDisconnected(stopCalled);
        }

        public void DeleteConnectionIDs()
        {
            string userName = Context.User.Identity.Name;
            string SessionID = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value;

            User user = (User)myCache.Get(userName);

            if (user.SessionID == SessionID)
                myCache.Remove(Context.User.Identity.Name);
        }
    }
}