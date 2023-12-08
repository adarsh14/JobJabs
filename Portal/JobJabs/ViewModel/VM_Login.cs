using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using JobJabs.Entity;

namespace JobJabs.ViewModel
{
    public class VM_Login
    {
        [Required(ErrorMessage = "Please enter Username")]
        public string LoginName { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }

        public string Message { get; set; }

        public VM_Login()
        {
            LoginName = "";
            Password = "";
            Message = "";
        }

        public static implicit operator Login(VM_Login model)
        {
            return new Login()
            {
                UserName = model.LoginName,
                Password = model.Password,
            };
        }
    }
}
