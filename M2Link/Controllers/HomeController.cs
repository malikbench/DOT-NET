using M2Link.Context;
using M2Link.Models;
using M2Link.Repositories;
using M2Link.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Mvc;

namespace M2Link.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            using (M2LinkContext context = new M2LinkContext())
            {
                MessageRepository msgRepo = new MessageRepository(context);
                List<MessageModel> messages = new List<MessageModel>();
                UserRepository userRepo = new UserRepository(context);
                List<string> list_follow = userRepo.getFollowedUsersPseudo(HttpContext.User.Identity.Name);

                foreach (Entities.Message msg in msgRepo.getMessages(list_follow))
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
                return View(messages);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}