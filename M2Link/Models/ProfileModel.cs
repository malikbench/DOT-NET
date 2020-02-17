using M2Link.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M2Link.Models
{
    public class ProfileModel
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

        [Display(Name = "Messages")]
        public List<MessageModel> Messages { get; set; }

        [Display(Name = "Utilisateurs suivis")]
        public List<string> Followings { get; set; }

        public ProfileModel()
        {
            this.Messages = new List<MessageModel>();
            this.Followings = new List<string>();
        }
    }
}
