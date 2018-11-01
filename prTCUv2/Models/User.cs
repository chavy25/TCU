using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace prTCUv2.Models
{
    public class User
    {
        #region Class Attributes
        public string UserID { get; set; }

        public bool Active { get; set; }

        public string Password { get; set; }

        public string LoginType { get; set; }

        public string Email { get; set; }
        #endregion
    }
}