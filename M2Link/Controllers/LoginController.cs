using M2Link.Context;
using M2Link.Entities;
using M2Link.Models;
using M2Link.Repositories;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace M2Link.Controllers
{
    public class LoginController : Controller
    {
        // GET : Form
        public ActionResult Form()
        {
            return View();
        }

        // POST : Form
        [HttpPost]
        public ActionResult Form(LoginModel model)
        {
            using (M2LinkContext context = new M2LinkContext())
            {
                UserRepository repo = new UserRepository(context);
                if (!repo.checkUser(model.Pseudo, model.Password))
                {
                    ModelState.AddModelError("Password", "Vos identifiants sont incorects.");
                }
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(model.Pseudo, true);
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        [HttpGet]
        public ActionResult Disconnect()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
