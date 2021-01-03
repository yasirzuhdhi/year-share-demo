using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ResolutionNewYear.Models;

namespace ResolutionNewYear.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        ApplicationDbContext db;
        public DashboardController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Dashboard
        public ActionResult Index()
        {
            var data = db.PostPages.ToList();
            return View(data);
        }
        public ActionResult CreatePage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePage(PostPage model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                PostPage page = new PostPage();
                page.Title = model.Title;
                page.CreatedAt = DateTime.Now;
                page.CreatedBy = User.Identity.Name;
                db.PostPages.Add(page);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult PageDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Id = id;
            var postPage = db.Posts.ToList();
            return View(postPage);
        }
        public ActionResult CreatePost(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePost(int id, Post model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Images/" + ImageName);
                file.SaveAs(physicalPath);
                Post po = new Post();
                po.Title = model.Title;
                po.Description = model.Description;
                po.ImagePath = ImageName;
                po.CreatedAt = model.CreatedAt;
                po.CreatedBy = User.Identity.Name;
                po.PostedType = model.PostedType;
                po.EventDate = DateTime.Now;
                po.CreatedAt = DateTime.Now;
                po.PageId = id;
                db.Posts.Add(po);
                db.SaveChanges();
                return RedirectToAction("PageDetails", new { id = id });
            }
            return View();
        }
    }
}