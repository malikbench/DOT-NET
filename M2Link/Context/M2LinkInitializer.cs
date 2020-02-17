using M2Link.Repositories;
using M2Link.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace M2Link.Context
{
    public class M2LinkInitializer : DropCreateDatabaseIfModelChanges<M2LinkContext>
    {
        public M2LinkInitializer() { }

        protected override void Seed(M2LinkContext context)
        {
            UserRepository repo = new UserRepository(context);
            if (repo.getUser("Malik") == null)
            {
                Entities.User user = new Entities.User()
                {
                    FirstName = "BENCHEMAM",
                    LastName = "Malik",
                    Email = "malikbcm@gmail.com",
                    Pseudo = "Malik",
                    Password = "Motdepasse76!"
                };
                List<Entities.User> followed_base = new List<Entities.User>();
                followed_base.Add(user);
                user.followed = followed_base;

                MessageRepository repoMsg = new MessageRepository(context);
                repoMsg.Add(new Entities.Message()
                {
                    auteur = user,
                    message = "Bienvenue sur mon application .NET !"
                });

                repo.Add(user);
                context.SaveChanges();
            }
        }
    }
}