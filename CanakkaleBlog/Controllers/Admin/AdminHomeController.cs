using CanakkaleBlog.Models;
using CanakkaleBlog.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CanakkaleBlog.Controllers
{  
    [RoutePrefix("Admin/Home")]
    [Route("{action=Index}")]
    public class AdminHomeController : Controller
    {
        DataContext db=new DataContext();
        // GET: AdminHome
      
        [Authorize(Roles="Admin")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(User user)
        {
            User userControl=new User();
            userControl=db.User.FirstOrDefault(x=> x.UserName==user.UserName
            && x.Password==user.Password && x.IsDelete==false);
            if (userControl != null)
            {
                if(userControl.IsActive==false)
                {
                    ViewBag.Mesaj = " bu kullanıcı actif değil ";
                     return View();
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(userControl.UserName, true);
                    if (userControl.RoleId == 1)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return Redirect("~/Home/Index");
                    }
                }
             
            }
            else
            {
                ViewBag.Mesaj = " kullanıcı adı ve şifre hatalı tekrar deneyiniz";
                return View();
            }
          
        }
    }
}