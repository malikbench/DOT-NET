using M2Link.Context;
using M2Link.Entities;
using M2Link.Models;
using M2Link.Repositories;
using M2Link.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace M2Link.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        // GET: User Index
        public ActionResult Index()
        {
            using (M2LinkContext context = new M2LinkContext())
            {
                UserRepository repo = new UserRepository(context);
                User user_base = repo.getUser(HttpContext.User.Identity.Name);
                UserModel user = new UserModel()
                {
                    Email = user_base.Email,
                    FirstName = user_base.FirstName,
                    LastName = user_base.LastName,
                    Pseudo = user_base.Pseudo
                };
                if (user == null)
                {
                    FormsAuthentication.SignOut();
                    return RedirectToAction("Index", "Home");
                } else
                {
                    List<MessageModel> messages = new List<MessageModel>();
                    foreach (Message msg in user_base.messages)
                    {
                        MessageModel msgModel = new MessageModel()
                        {
                            guid = msg.guid,
                            auteur = msg.auteur.Pseudo,
                            date = msg.date,
                            message = msg.message
                        };
                        messages.Add(msgModel);
                    }

                    List<string> followed_users = new List<string>();
                    foreach (User u in user_base.followed)
                    {
                        followed_users.Add(u.Pseudo);
                    }

                    ProfileModel profile_user = new ProfileModel()
                    {
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Pseudo = user.Pseudo,
                        Messages = messages,
                        Followings = followed_users
                    };
                    return View(profile_user);
                }
            }
        }

        // GET: Edit
        public ActionResult Edit()
        {
            using (M2LinkContext context = new M2LinkContext())
            {
                UserRepository repo = new UserRepository(context);
                User user_base = repo.getUser(HttpContext.User.Identity.Name);
                UserModel user = new UserModel()
                {
                    Email = user_base.Email,
                    FirstName = user_base.FirstName,
                    LastName = user_base.LastName,
                    Pseudo = user_base.Pseudo
                };
                if (user == null)
                {
                    FormsAuthentication.SignOut();
                    return RedirectToAction("Index", "Home");
                }
                ProfileModel profile_user = new ProfileModel()
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Pseudo = user.Pseudo,
                };
                return View(profile_user);
            }
        }

        // GET: Edit
        public ActionResult ChangePassword()
        {
            return View();
        }

        // POST: Edit
        [HttpPost]
        public ActionResult Edit(ProfileModel profile)
        {
            //Si l'on a plus les informations du User dans la Database
            using (M2LinkContext context = new M2LinkContext())
            {
                UserRepository repo = new UserRepository(context);
                User user = repo.getUser(HttpContext.User.Identity.Name);
                if (user == null)
                {
                    FormsAuthentication.SignOut();
                    return RedirectToAction("Index", "Home");
                }
                repo.EditUser(HttpContext.User.Identity.Name, profile);
                context.SaveChanges();
                return RedirectToAction("Index", "Profile");
            }
        }

        // POST: Edit
        [HttpPost]
        public ActionResult ChangePassword(ProfilePasswordModel model)
        {
            //Si l'on a plus les informations du User dans la Database
            using (M2LinkContext context = new M2LinkContext())
            {
                UserRepository repo = new UserRepository(context);
                User user = repo.getUser(HttpContext.User.Identity.Name);
                if (user == null)
                {
                    FormsAuthentication.SignOut();
                    return RedirectToAction("Index", "Home");
                }
                repo.changePassword(HttpContext.User.Identity.Name, model.Password);
                context.SaveChanges();
                return RedirectToAction("Index", "Profile");
            }
        }



        // GET: List
        public ActionResult List()
        {
            using (M2LinkContext context = new M2LinkContext())
            {
                UserRepository repo = new UserRepository(context);

                var profiles = repo.GetAll().Select(u => new ProfileModel()
                {
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Pseudo = u.Pseudo
                }).ToList();

                //Followers
                ProfileModel p_user = profiles.Find(p => p.Pseudo == HttpContext.User.Identity.Name);
                foreach (string s in repo.getFollowedUsersPseudo(HttpContext.User.Identity.Name))
                {
                    p_user.Followings.Add(s);
                }

                return View(profiles);
            }
        }

        // GET: Follow
        public ActionResult Follow(string pseudo, string source)
        {
            using (M2LinkContext context = new M2LinkContext())
            {
                UserRepository repo = new UserRepository(context);
                repo.Follow(HttpContext.User.Identity.Name, pseudo);
                context.SaveChanges();
            }
            return RedirectToAction("List", "Profile");
        }

        // GET: Follow
        public ActionResult Unfollow(string nickname, string source)
        {
            using (M2LinkContext context = new M2LinkContext())
            {
                UserRepository repo = new UserRepository(context);
                repo.Unfollow(HttpContext.User.Identity.Name, nickname);
                context.SaveChanges();
            }
            return RedirectToAction("List", "Profile");
        }

    }
}