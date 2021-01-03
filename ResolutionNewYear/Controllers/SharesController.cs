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
    public class SharesController : Controller
    {
        ApplicationDbContext db;
        public SharesController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Shares
        public ActionResult Index()
        {
            var data = db.Shares.ToList();
            return View(data);
        }
        public ActionResult ShareAPage()
        {
            ViewBag.PageId = new SelectList(db.PostPages.Where(c => c.CreatedBy == User.Identity.Name).ToList(), "Id", "Title");
            return View();
        }
        [HttpPost]
        public ActionResult ShareAPage(Shares share)
        {
            Shares sh = new Shares();
            ViewBag.PageId = new SelectList(db.PostPages.Where(c => c.CreatedBy == User.Identity.Name).ToList(), "Id", "Title");
            sh.Message = share.Message;
            sh.SharedBy = User.Identity.Name;
            sh.SharedTo = share.SharedTo;
            sh.PageId = share.PageId;
            db.Shares.Add(sh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SharedToYou()
        {
            var name = (from a in db.PostPages
                        join b in db.Shares on a.Id equals b.PageId into found
                        from b in found.DefaultIfEmpty()
                        select new {
                        a.Title
                        }).FirstOrDefault();
            var data = db.Shares.ToList();
            return View(data);
        }
    }
}