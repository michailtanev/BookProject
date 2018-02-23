using Microsoft.AspNet.Identity;
using SchoolBookApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolBookApplication.Web.Controllers
{
    public class UserController : Controller
    {
        [Authorize()]
        ActionResult UserDetails()
        {
            var UserId = User.Identity.GetUserId();
            var db = new SchoolBookDbContext();
            var comp = db.Users.Where(i => i.UserName == UserId).First();
            return View(comp);
        }
    }
}