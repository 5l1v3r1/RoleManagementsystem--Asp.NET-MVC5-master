using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Role_Management_System.Models
{
    public class RegisterModel
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

    }
}