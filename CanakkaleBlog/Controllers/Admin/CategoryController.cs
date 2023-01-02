using CanakkaleBlog.Models.Entity;
using CanakkaleBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CanakkaleBlog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        // GET: Category
      
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View(db.Category.Where(x => x.IsDelete == false).ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(Category Category)
        {
            Category newCategory = db.Category.FirstOrDefault(x => x.Name == Category.Name && x.IsDelete == false);
            if (newCategory != null)
            {
                ViewBag.mesaj = "aynı isimde Category tanımlayamazsınız";
                return Redirect(Request.UrlReferrer.ToString());
            }
            newCategory = new Category();
            newCategory.Name = Category.Name;
            newCategory.IsActive = Category.IsActive;
            db.Category.Add(newCategory);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            if (Id == 1 || Id == 2)
            {
                return RedirectToAction("Index");
            }
            Category editCategory = db.Category.FirstOrDefault(x => x.Id == Id && x.IsDelete == false);
            if (editCategory == null)
            {
                return RedirectToAction("Index");

            }
            return View(editCategory);

        }
        [HttpPost]
        public ActionResult Edit(int Id, string Name, bool? IsActive)
        {

            Category editCategory = db.Category.FirstOrDefault(x => x.Id == Id && x.IsDelete == false);
            if (editCategory == null)
            {
                return RedirectToAction("Index");

            }
            Category CategoryControl = db.Category.FirstOrDefault(x => x.Name == Name && x.Id != Id && x.IsDelete == false);
            if (CategoryControl != null)
            {
                ViewBag.Mesaj = "aynı isimde Category tanımlayamazsınız";
                return View(editCategory);//sayfayı yeniler
            }

            editCategory.Name = Name;
            if (IsActive == null)
            {
                editCategory.IsActive = false;
            }
            else
            {
                editCategory.IsActive = true;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            if (Id == 1 || Id == 2)
            {
                return RedirectToAction("Index");
            }
            Category delCategory = db.Category.FirstOrDefault(x => x.Id == Id);
            if (delCategory == null)
            {
                return RedirectToAction("Index");
            }
            delCategory.IsDelete = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
