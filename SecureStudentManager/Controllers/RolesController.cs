using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SecureStudentManager.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SecureStudentManager.Models;

namespace SecureStudentManager.Controllers
{
    public class RolesController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Roles
        public ActionResult Index()
        {
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roles = rm.Roles.ToList();
            return View(roles);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Role role)
        {
            if (ModelState.IsValid)
            {
                var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                rm.Create(new IdentityRole(role.RoleName));

                return RedirectToAction("Index");
            }
            return View(role);
        }

        [HttpGet]
        public ActionResult AddUserToRoles()
        {
            //get all users
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var userList = um.Users.Select(x => new UsersViewModel { UserId = x.Id, UserName = x.UserName }).ToList();

            //get all roles
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleList = rm.Roles.Select(x => new RolesViewModel { RoleId = x.Id, RoleName = x.Name }).ToList();

            ViewBag.Users = new SelectList(userList, "UserId", "UserName");
            ViewBag.Roles = new SelectList(roleList, "RoleId", "RoleName");

            return View(new UserToRolesViewModel { AllRoles = roleList, AllUsers = userList });

        }

        [HttpPost]
        public ActionResult AddUserToRoles(string UserId, string RoleId)
        {
            if (UserId != null && RoleId != null)
            {
                var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                var correspondingUserId = um.Users.Where(x => x.Id == UserId).Select(x => x.Id).SingleOrDefault();
                var correspondingRole = rm.Roles.Where(x => x.Id == RoleId).Select(x => x.Name).SingleOrDefault();

                um.AddToRole(correspondingUserId, correspondingRole);

            }
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
