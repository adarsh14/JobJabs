using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using JobJabs.Entity;

namespace JobJabs.Entity
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EncryptedPassword
        {
            get
            {
                Crypto c = new Crypto(Crypto.CryptoTypes.encTypeTripleDES);
                return c.Encrypt(!string.IsNullOrEmpty(Password) ? Password : "");
            }
        }
        public string DecryptedPassword
        {
            get
            {
                if (!string.IsNullOrEmpty(Password))
                {
                    Crypto c = new Crypto(Crypto.CryptoTypes.encTypeTripleDES);
                    return c.Decrypt(Password);
                }
                return "";
            }
        }
        public string DeviceId { get; set; }
        public int SiteId { get; set; }
        public int LoginStatus { get; set; }
        public Login()
        {
              UserName = "";
              Password = "";
       }

        public static implicit operator RLogin(Login model)
        {
            return new RLogin()
            {
                UserName = model.UserName,
                Password = model.EncryptedPassword ,
            };
        }

       

    }
   
}
