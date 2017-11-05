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
        public ActionResult Create(CreateBookViewModel b)
        {
            if (ModelState.IsValid)
            {
                var user = User.Identity.GetUserId();
                byte[] content = null;
                string fileExtension = null;
                if (b.UploadPhoto != null)
                {
                    using (var mem = new MemoryStream())
                    {
                        b.UploadPhoto.InputStream.CopyTo(mem);
                        content = mem.GetBuffer();                      
                        fileExtension = b.UploadPhoto.FileName.Split(new[] { '.' }).Last();
                    }
                }

                Book book = new Book
                {
                    OriginalPrice = b.OriginaPrice ?? 0,
                    SalePrice = b.SalePrice ?? 0,
                    Type = new BookType { Name = b.Title, Year = b.Year ?? 0, BookCategory = new BookCategory { Name = b.Category } },
                    ListingDate = DateTime.Now,
                    SellerId = user,
                    Author=b.Author,
                    AdditionalInformation = b.AdditionalInformation,
                    Image = new Image { Content = content, FileExtension = fileExtension }
                };

                this.Data.Books.Add(book);
                this.Data.SaveChanges();
            }
            TempData["Success"] = "Added Successfully!";
            return RedirectToAction("Create", "CreateBook");
        }

    }
}