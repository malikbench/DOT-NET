using M2Link.Context;
using M2Link.Entities;
using M2Link.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace M2Link.Repositories
{
    public class UserRepository
    {
        public M2LinkContext context { get; set; }

        public UserRepository(M2LinkContext context)
        {
            this.context = context;
        }

        public void Remove(User user)
        {
            CheckParameter("user", user);

            // L'utilisateur existe
            if (FindByUsername(user.Pseudo) == null)
            {
                throw new ApplicationException("L'utilisateur n'existe pas");
            }

            // Supprime l'utilisateur de la BDD
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public void Add(User user)
        {
            context.Users.Add(user);
        }

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public Boolean checkUser(string nickname, string password)
        {
            return context.Users.Any(user => user.Pseudo == nickname && user.Password == password);
        }

        public User getUser(string pseudo)
        {
            return context.Users.SingleOrDefault(user => user.Pseudo == pseudo);
        }

        public void EditUser(string Pseudo, ProfileModel Profile)
        {
            User entityUser = getUser(Pseudo);
            entityUser.Pseudo = Profile.Pseudo;
            entityUser.FirstName = Profile.FirstName;
            entityUser.LastName = Profile.LastName;
            entityUser.Email = Profile.Email;
        }

        public void changePassword(string Pseudo, string Password)
        {
            User entityUser = getUser(Pseudo);
            entityUser.Password = Password;
        }




 


        //FOLLOW
        public List<User> getFollowedUsers(string nickname)
        {
            return getFollowedUsers(getUser(nickname)).ToList();
        }

        public List<User> getFollowedUsers(User user)
        {
            if (user == null) return new List<User>();
            return user.followed.ToList();
        }

        public User FindByUsername(string pseudo)
        {
            CheckParameter("Pseudo", pseudo);
            return context.Users.FirstOrDefault(u => u.Pseudo.ToLower() == pseudo.ToLower());
        }

        public List<string> getFollowedUsersPseudo(string pseudo)
        {
            return getFollowedUsersPseudo(getUser(pseudo));
        }

        public List<string> getFollowedUsersPseudo(User user)
        {
            List<string> pseudos = new List<string>();
            if (user == null) return pseudos;
            foreach (var item in user.followed)
            {
                pseudos.Add(item.Pseudo);
            }
            return pseudos;
        }

        public void Follow(string pseudo, string pseudo_to_follow)
        {
            User user = getUser(pseudo);
            User user_to_follow = getUser(pseudo_to_follow);
            if (!user.followed.Contains(user_to_follow))
            {
                user.followed.Add(user_to_follow);
            }
        }

        public void Unfollow(string pseudo, string pseudo_to_unfollow)
        {
            User user = getUser(pseudo);
            User user_to_unfollow = getUser(pseudo_to_unfollow);
            if (user.followed.Contains(user_to_unfollow))
            {
                user.followed.Remove(user_to_unfollow);
            }
        }



        //Outils
        private void CheckParameter(string paramName, object paramValue)
        {
            // Gestion d'erreur sur le paramètre
            if (paramValue == null)
            {
                throw new ApplicationException("Le paramètre " + paramName + " ne peut pas être null");
            }
        }
    }
}