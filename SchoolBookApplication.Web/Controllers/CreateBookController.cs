namespace SchoolBookApplication.Web.Controllers
{
    using Domain;
    using Microsoft.AspNet.Identity;
    using SchoolBookApplication.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class CreateBookController : BaseController
    {
  
        [Authorize]
        public ActionResult Create()
        {
            var model = new CreateBookViewModel();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(CreateBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = User.Identity.GetUserId();
                byte[] content = null;
                string fileExtension = null;
                if (model.UploadPhoto != null)
                {
                    using (var mem = new MemoryStream())
                    {
                        model.UploadPhoto.InputStream.CopyTo(mem);
                        content = mem.GetBuffer();                      
                        fileExtension = model.UploadPhoto.FileName.Split(new[] { '.' }).Last();
                    }
                }

                Book book = new Book
                {
                    OriginalPrice = model.OriginaPrice ?? 0,
                    SalePrice = model.SalePrice ?? 0,
                    Type = new BookType { Name = model.Title, Year = model.Year ?? 0, BookCategory = new BookCategory { Name = model.Category } },
                    CreatedOn = DateTime.Now,
                    SellerId = user,
                    Author=model.Author,
                    AdditionalInformation = model.AdditionalInformation,
                    Image = new Image { Content = content, FileExtension = fileExtension }
                };

                this.Data.Books.Add(book);
                this.Data.SaveChanges();
            }
            TempData["Success"] = "Your Book Has Been Added Successfully!";
            return RedirectToAction("Create", "CreateBook");
        }

    }
}