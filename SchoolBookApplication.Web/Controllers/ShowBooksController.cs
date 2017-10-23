using SchoolBookApplication.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolBookApplication.Web.Controllers
{
    public class ShowBooksController : BaseController
    {

        private IQueryable<BookViewModel> GetAllBooks()
        {
            var listbook = this.Data.Books.All().Select(x => new BookViewModel
            {
                Id = x.BookId,
                ImageId = x.Image.ImageId,
                Category = x.Type.BookCategory.Name,
                Type = x.Type.Name,
                SellerFirstName=x.Seller.Name,
                ListingDate = x.ListingDate,
                Price = x.SalePrice
            }).OrderByDescending(x => x.ListingDate);

            return listbook;
        }

        public ActionResult Show()
        {
            var viewModel = GetAllBooks();
            return View(viewModel);
        }

        public ActionResult Image(int id)
        {
            var image = this.Data.Images.GetById(id);
            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }
            return File(image.Content, "image/" + image.FileExtension);
        }
       
    }
}