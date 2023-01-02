using CanakkaleBlog.Models;
using CanakkaleBlog.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CanakkaleBlog.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class AdminSocialMediaController : Controller
    {
        DataContext db = new DataContext();
        // GET: AdminSocialMedia
        public ActionResult Index()
        {
            List<SocialMedia> socialMedias= new List<SocialMedia>();
            socialMedias=db.SocialMedia.Where(x=> x.IsDelete== false).ToList();
            return View(socialMedias);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost] 
        public ActionResult Create(SocialMedia socialMedia)
        {
            SocialMedia CreateSocial = new SocialMedia();
            CreateSocial.Name= socialMedia.Name;
            CreateSocial.Link= socialMedia.Link;
            CreateSocial.IsActive= socialMedia.IsActive;
            db.SocialMedia.Add(CreateSocial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            SocialMedia socialMedia = new SocialMedia();
            socialMedia=db.SocialMedia.FirstOrDefault(x=>x.Id==id);
            return View(socialMedia);
        }
        [HttpPost]
        public ActionResult Edit(SocialMedia social)
        {
            SocialMedia social1 = new SocialMedia();
            social1 = db.SocialMedia.FirstOrDefault(x => x.Id == social.Id);
            social1.Name= social.Name;
            social1.Link= social.Link;
            social1.IsActive= social.IsActive;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            SocialMedia socialMedia = new SocialMedia();
            socialMedia = db.SocialMedia.FirstOrDefault(x => x.Id == id);
            socialMedia.IsDelete= true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}