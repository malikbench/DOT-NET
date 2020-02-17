using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M2Link.Entities
{
    public class Message
    {
        [KeyAttribute]
        public virtual Guid guid { get; set; }

        public User auteur { get; set; }

        public string message { get; set; }

        public DateTime date { get; set; }

        public Message()
        {
            this.guid = Guid.NewGuid();
            this.date = DateTime.Now;
        }

        public Message(User auteur, string message)
        {
            this.guid = Guid.NewGuid();
            this.auteur = auteur;
            this.message = message;
            this.date = DateTime.Now;
        }
    }
}
