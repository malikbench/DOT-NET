using M2Link.Context;
using M2Link.Entities;
using M2Link.Models;
using M2Link.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace M2Link.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Form
        public ActionResult Form() => View();

        // POST : Form
        [HttpPost]
        public ActionResult Form(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                User user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Pseudo = model.Pseudo,
                    Password = model.Password
                };

                using (M2LinkContext context = new M2LinkContext())
                {
                    UserRepository repo = new UserRepository(context);
                    repo.Add(user);
                    context.SaveChanges();
                }
                FormsAuthentication.SetAuthCookie(model.Pseudo, true);
                return RedirectToAction("Index", "Home");
            }
        }
    }
}