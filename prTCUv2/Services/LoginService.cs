using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using prTCUv2.Models;
using System.Data;

namespace prTCUv2.Services
{
    public class LoginService
    {

        public string LoginCustomer(User Customer)
        {
            return "Manager";
        }

        public void UserConnected(string CustomerID, string Module)
        {
            UserDisconnected(CustomerID, Module);
        }

        public void UserDisconnected(string CustomerID, string Module)
        {
        }

    }
}