using SchoolBookApplication.Data;
using SchoolBookApplication.Domain;
using SchoolBookApplication.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolBookApplication.Web.Controllers
{
    public class SearchBookController : BaseController
    {
        [HttpGet]
        public ActionResult Search()
        {
            SearchBookViewModel model = new SearchBookViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Search(SearchBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                string carBrand = Convert.ToString(model.BookType);
                var db = new SchoolBookDbContext();
                IEnumerable<Book> cars = db.Books
                    .Where(x => x.Type.Name == carBrand
                    || x.Type.BookCategory.Name == carBrand)
                    .ToList();
                return PartialView("_SearchBook", cars);
            }
            return Json("Error");
        }
    }
}