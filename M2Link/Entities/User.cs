using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M2Link.Entities
{
    public class User
    {
        [KeyAttribute]
        public virtual Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Pseudo { get; set; }
        public string Password { get; set; }

        public virtual List<User> followed { get; set; }
        public virtual List<User> followed_by { get; set; }
        public virtual List<Message> messages { get; set; }

        public User()
        {
            this.Guid = Guid.NewGuid();
            this.followed = new List<User>();
            this.followed_by = new List<User>();
            this.messages = new List<Message>();
        }
    }
}