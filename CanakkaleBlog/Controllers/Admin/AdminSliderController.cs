using CanakkaleBlog.Models;
using CanakkaleBlog.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CanakkaleBlog.Controllers.Admin
{
  //  [Authorize(Roles ="Admin,USer")]
    [Authorize(Roles ="Admin")]
    public class AdminSliderController : Controller
    {
        // GET: AdminSlider
        DataContext db=new DataContext();
        public ActionResult Index()
        {
            return View(db.Slider.Where(x=> x.IsDelete==false).ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Slider slider,HttpPostedFileBase Image)
        {
            Slider NewSlider = new Slider();

            if(Image!=null && Image.ContentLength > 0)
            {
                string ImagePath = "", ImageName = "";
                ImageName = Guid.NewGuid().ToString().Substring(0, 8) + "-" + Path.GetFileName(Image.FileName);
                ImagePath = Path.Combine(Server.MapPath("~/Content/assets/images/Slider"), ImageName);
                Image.SaveAs(ImagePath);
                NewSlider.Image = ImageName;
            
            
            }
            NewSlider.Name = slider.Name;
            NewSlider.Link = slider.Link;
            NewSlider.IsActive = slider.IsActive;
            db.Slider.Add(NewSlider);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Slider slider = db.Slider.FirstOrDefault(x => x.Id == id && x.IsDelete==false);
            if (slider == null)
            {
                return RedirectToAction("index");
                    
            }

            return View(slider);
        }
        public ActionResult Edit(Slider slider,HttpPostedFileBase Image)
        {
            Slider EditSlider = db.Slider.FirstOrDefault(x =>
            x.Id == slider.Id && x.IsDelete == false);
            if (EditSlider == null)
            {
                 return RedirectToAction("index");
            }
           if(Image!=null && Image.ContentLength > 0)
            {
                string imageName = "", imagePath = "";
                imageName = Guid.NewGuid().ToString().Substring(0, 8)+ "-" + Path.GetFileName(Image.FileName);
                imagePath = Path.Combine(Server.MapPath("~/Content/assets/images/Slider"), imageName);
                Image.SaveAs(imagePath);
                EditSlider.Image = imageName;

            }
            EditSlider.Name = slider.Name;
            EditSlider.Link  = slider.Link;
            EditSlider.IsActive = slider.IsActive;
            db.SaveChanges();

            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            Slider delSlider = db.Slider.Find(id);
            if (delSlider == null)
            {
                return RedirectToAction("index");
            }
            delSlider.IsDelete = true;
            db.SaveChanges();
            return RedirectToAction("index");
        }

    }
}