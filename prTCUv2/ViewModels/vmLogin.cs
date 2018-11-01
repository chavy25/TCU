using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prTCUv2.Models;

namespace prTCUv2.ViewModels
{
    public class vmLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LoginType { get; set; }

        public static implicit operator vmLogin(User User)
        {
            var vm = new vmLogin
            {
                UserName = User.UserID,
                Password = User.Password
            };

            return vm;
        }

        public static implicit operator User(vmLogin vm)
        {
            var User = new User
            {
                UserID = vm.UserName,
                Password = vm.Password
            };

            return User;
        }
    }
}