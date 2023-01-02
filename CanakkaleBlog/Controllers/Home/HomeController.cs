using CanakkaleBlog.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CanakkaleBlog.Controllers.Home
{
    public class HomeController : Controller
    {
        // GET: Home
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            var sliderlist = db.Slider.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            return View(sliderlist);
        }
    }
}