using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prTCUv2.Areas.Admin.Models
{
    public class Persona
    {
       
        public int id { get; set; }

         
        public string nombre { get; set; }

        
        public string telefono { get; set; }

        
        public string email { get; set; }

        
        public string direccion { get; set; }
    }
}