using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeraRecon.Models;

namespace TeraRecon.Controllers
{
    public class LabelController : Controller
    {
        private LabelDBContext db = new LabelDBContext();

        // GET: /Label/
        public ActionResult Index()
        {
            return View(db.labels.ToList());
        }


        public JsonResult AutoComplete(string term)
        {
            List<Labels> labels = db.labels.ToList();
            List<Labels> result = new List<Labels>();

            if (labels == null)
            {
                result[0].Id = int.MinValue;
                result[0].item = "Not found";
                result[0].label = "Not found";
                return Json(result, JsonRequestBehavior.AllowGet); 
            }

            foreach(Labels label in labels){
                if(label.label.ToLower().Contains(term)){
                    result.Add(label);                    
                }
            }
            if (result == null)
            {
                result[0].Id = int.MinValue;
                result[0].item = "Not found";
                result[0].label = "Not found";
                return Json(result, JsonRequestBehavior.AllowGet); 
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Search(string term)
        {
            List<Labels> labels = db.labels.ToList();
            List<Labels> result = new List<Labels>();

            if (labels == null)
            {
                return HttpNotFound();
            }

            foreach (Labels label in labels)
            {
                if (label.label.ToLower().StartsWith(term))
                {
                    result.Add(label);
                }
            }

            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // GET: /Label/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Labels labels = db.labels.Find(id);
            if (labels == null)
            {
                return HttpNotFound();
            }
            return View(labels);
        }

        // GET: /Label/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Label/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,item,label")] Labels labels)
        {
            if (ModelState.IsValid)
            {
                db.labels.Add(labels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(labels);
        }

        // GET: /Label/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Labels labels = db.labels.Find(id);
            if (labels == null)
            {
                return HttpNotFound();
            }
            return View(labels);
        }

        // POST: /Label/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,item,label")] Labels labels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(labels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(labels);
        }

        // GET: /Label/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Labels labels = db.labels.Find(id);
            if (labels == null)
            {
                return HttpNotFound();
            }
            return View(labels);
        }

        // POST: /Label/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Labels labels = db.labels.Find(id);
            db.labels.Remove(labels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private class JsonValues
        {
            public string label;
            public string value;
        }
    }

    
}
