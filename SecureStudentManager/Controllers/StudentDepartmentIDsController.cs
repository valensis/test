using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SecureStudentManager.Models;

namespace SecureStudentManager.Controllers
{
    public class StudentDepartmentIDsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentDepartmentIDs
        public ActionResult Index()
        {
            return View(db.StudentDepartmentIDs.ToList());
        }

        // GET: StudentDepartmentIDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDepartmentIDs studentDepartmentIDs = db.StudentDepartmentIDs.Find(id);
            if (studentDepartmentIDs == null)
            {
                return HttpNotFound();
            }
            return View(studentDepartmentIDs);
        }

        // GET: StudentDepartmentIDs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentDepartmentIDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,Department,Details")] StudentDepartmentIDs studentDepartmentIDs)
        {
            if (ModelState.IsValid)
            {
                db.StudentDepartmentIDs.Add(studentDepartmentIDs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentDepartmentIDs);
        }

        // GET: StudentDepartmentIDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDepartmentIDs studentDepartmentIDs = db.StudentDepartmentIDs.Find(id);
            if (studentDepartmentIDs == null)
            {
                return HttpNotFound();
            }
            return View(studentDepartmentIDs);
        }

        // POST: StudentDepartmentIDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,Department,Details")] StudentDepartmentIDs studentDepartmentIDs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentDepartmentIDs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentDepartmentIDs);
        }

        // GET: StudentDepartmentIDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDepartmentIDs studentDepartmentIDs = db.StudentDepartmentIDs.Find(id);
            if (studentDepartmentIDs == null)
            {
                return HttpNotFound();
            }
            return View(studentDepartmentIDs);
        }

        // POST: StudentDepartmentIDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentDepartmentIDs studentDepartmentIDs = db.StudentDepartmentIDs.Find(id);
            db.StudentDepartmentIDs.Remove(studentDepartmentIDs);
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
    }
}
