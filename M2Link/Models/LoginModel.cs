using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M2Link.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Veuillez entrer le Pseudo")]
        [MaxLength(30, ErrorMessage = "Le Pseudo est trop long (30 caractères max.)")]
        [DisplayName("Pseudo")]
        public string Pseudo { get; set; }

        [Required(ErrorMessage = "Veuillez entrer le mot de passe")]
        [DataType(DataType.Password)]
        [DisplayName("Mot de passe")]
        public string Password { get; set; }

        public LoginModel() { }

        public LoginModel(string pseudo, string password)
        {
            this.Pseudo = pseudo;
            this.Password = password;
        }
    }
}