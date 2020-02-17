using M2Link.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M2Link.Models
{
    public class ProfilePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Vérification du mot de passe")]
        [Compare("Password")]
        public string VerifyPassword { get; set; }

        public ProfilePasswordModel()
        {
        }

        public ProfilePasswordModel(string password, string verify_password)
        {
            this.Password = password;
            this.VerifyPassword = verify_password;
        }

        public ProfilePasswordModel(User user)
        {
            this.Password = user.Password;
            this.VerifyPassword = user.Password;
        }
    }
}