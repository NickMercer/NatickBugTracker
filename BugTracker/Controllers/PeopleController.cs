using BugTracker.Models;
using BugTracker.View_Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracker.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext context;

        public PeopleController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        [Authorize(Roles = Roles.Admin + "," + Roles.ProjectLead)]
        public ActionResult Index()
        {
           
            return View();
        }

        // GET: People/Edit/Id
        public ActionResult Edit(string id)
        {
            var user = context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                return HttpNotFound();

            if (user.Id != id && !User.IsInRole(Roles.Admin)) return new HttpUnauthorizedResult();


            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var roles = roleManager.Roles.Select(x => x.Name).ToList();

            var currentRoleId = user.Roles.FirstOrDefault().RoleId;
            var currentRole = context.Roles.SingleOrDefault(r => r.Id == currentRoleId).Name;

            var viewModel = new UserFormViewModel(user, roles, currentRole);

            return View("UserForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(UserFormViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View("UserForm", user);
            }

            var userInDb = context.Users.Single(u => u.Id == user.Id.ToString());

            userInDb.UserName = user.UserName;
            userInDb.Email = user.Email;

            var currentRoleId = userInDb.Roles.FirstOrDefault().RoleId;
            var currentRole = context.Roles.SingleOrDefault(r => r.Id == currentRoleId).Name;

            if (currentRole != user.Role)
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                userManager.RemoveFromRole(userInDb.Id, currentRole);
                userManager.AddToRole(userInDb.Id, user.Role);
            }


            context.SaveChanges();

            return RedirectToAction("Index", "People");
        }

    }
}