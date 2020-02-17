using M2Link.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M2Link.Models
{
    public class MessageModel
    {
        [Display(Name = "Guid")]
        public Guid guid { get; set; }

        [Required]
        [Display(Name = "Message")]
        public string message { get; set; }

        [Required]
        [Display(Name = "Auteur")]
        public string auteur { get; set; }

        [Display(Name = "Date d'envoi du message")]
        public DateTime date { get; set; }

        public MessageModel()
        {
        }

        public MessageModel(Message msg)
        {
            this.guid = msg.guid;
            this.message = msg.message;
            this.auteur = msg.auteur.Pseudo;
            this.date = msg.date;
        }

    }
}
