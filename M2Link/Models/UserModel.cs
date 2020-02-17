using M2Link.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M2Link.Models
{
    public class UserModel
    {
        [Required]
        [Display(Name = "Nom")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Adresse email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Pseudo")]
        public string Pseudo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        public UserModel() { }

        public UserModel(User user)
        {
            this.LastName = user.LastName;
            this.FirstName = user.FirstName;
            this.Email = user.Email;
            this.Pseudo = user.Pseudo;
            this.Password = user.Password;
        }

        public UserModel(string LastName, string FirstName, string Email, string Pseudo, string Password)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Email = Email;
            this.Pseudo = Pseudo;
            this.Password = Password;
        }
    }
}