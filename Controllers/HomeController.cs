using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tiyatro_Takip.Models;
namespace Tiyatro_Takip.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        //[ValidateAntiForgeryToken]
        public ActionResult Login(UserProfile userObj)
        {
            if (ModelState.IsValid)
            { 
                using (TiyatroEntities2 db = new TiyatroEntities2())
                {
                    var obj = db.UserProfile.Where(a => a.UserName.Equals(userObj.UserName) && a.Password.Equals(userObj.Password)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["UserId"] = obj.UserId.ToString();
                        Session["Username"] = obj.UserName.ToString();
                        return RedirectToAction("AnaSayfa");

                    }

                }

            }
            return View(userObj);
        }
        public ActionResult Anasayfa()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}