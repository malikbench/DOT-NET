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

namespace M2Link.Controllers
{
    public class MessageController : Controller
    {
        // GET: Send
        public ActionResult Send()
        {
            return View(new MessageModel());
        }

        // POST: Send
        [HttpPost]
        public ActionResult Send(MessageModel model)
        {
            using (M2LinkContext context = new M2LinkContext())
            {
                UserRepository userRepo = new UserRepository(context);
                User user = userRepo.getUser(HttpContext.User.Identity.Name);
                Message msg = new Message()
                {
                    auteur = user,
                    date = DateTime.Now,
                    guid = Guid.NewGuid(),
                    message = model.message
                };

                MessageRepository msgRepo = new MessageRepository(context);
                msgRepo.Add(msg);
                user.messages.Add(msg);

                context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

        //GET : Delete
        public ActionResult Delete(MessageModel model)
        {
            using (M2LinkContext context = new M2LinkContext())
            {
                MessageRepository msgRepo = new MessageRepository(context);
                Message message = msgRepo.Get(model.guid);
                if (message == null)
                {
                    return RedirectToAction("Index", "Profile");
                }
                else
                {
                    return View(model);
                }
            }
        }

        //POST : Delete
        [HttpPost]
        public ActionResult DeletePost(MessageModel model)
        {
            using (M2LinkContext context = new M2LinkContext())
            {
                MessageRepository msgRepo = new MessageRepository(context);
                msgRepo.Delete(model.guid);

                context.SaveChanges();
            }
            return RedirectToAction("Index", "Profile");
        }

    }
}
