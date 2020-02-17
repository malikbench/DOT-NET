using M2Link.Context;
using M2Link.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M2Link.Repository
{
    public class MessageRepository
    {
        public M2LinkContext context { get; set; }

        public MessageRepository(M2LinkContext context)
        {
            this.context = context;
        }

        public List<Message> getMessages(string username)
        {
            return context.Messages.Where(message => message.auteur.Pseudo == username).ToList();
        }

        public List<Message> getMessages(List<string> usernames)
        {
            return (context.Messages.Where(message => usernames.Contains(message.auteur.Pseudo)).ToList());
        }

        public Message Get(Guid guid)
        {
            return context.Messages.SingleOrDefault(message => message.guid == guid);
        }

        public void Add(Message message)
        {
            context.Messages.Add(message);
        }

        public void Delete(Guid guid)
        {
            Message msg = Get(guid);
            context.Messages.Remove(msg);
        }

        public void Edit(Message message)
        {
            Message msg = Get(message.guid);
            msg.message = message.message;
            msg.auteur = message.auteur;
        }
    }
}
