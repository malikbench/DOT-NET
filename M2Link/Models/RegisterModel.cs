using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M2Link.Models
{
    public class RegisterModel
    {
        [Required]
        [DisplayName("Nom")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Pseudo")]
        public string Pseudo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Mot de passe")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirmation du mot de passe")]
        public string VerifyPassword { get; set; }

        public RegisterModel() { }
    }

}