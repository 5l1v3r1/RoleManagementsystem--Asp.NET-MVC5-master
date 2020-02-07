using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Role_Management_System.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}