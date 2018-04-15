using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SchoolBookApplication.Data;
using SchoolBookApplication.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SchoolBookApplication.Web.Controllers
{
    public class HomeController : BaseController
    {
        private IQueryable<BookViewModel> GetAllBooks()
        {
            var listbook = this.Data.Books.All().Select(x => new BookViewModel
            {
                Id = x.BookId,
                ImageId = x.Image.ImageId,
                Category = x.Type.BookCategory.Name,
                Type = x.Type.Name,
                ListingDate = x.CreatedOn,
                Price = x.SalePrice,
            }).OrderByDescending(x => x.ListingDate);

            return listbook;
        }
        public ActionResult Index()
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

        public FileContentResult UserPhotos()
        {
            if (User.Identity.IsAuthenticated)
            {
                String userId = User.Identity.GetUserId();

                if (userId == null)
                {
                    string fileName = HttpContext.Server.MapPath(@"..SchoolBookApplication.Data/Images/noImg.png");

                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);

                    return File(imageData, "image/png");

                }
                // to get the user details to load user Image
                var dbUsers = HttpContext.GetOwinContext().Get<SchoolBookDbContext>();
                var userImage = dbUsers.Users.Where(x => x.Id == userId).FirstOrDefault();

                return new FileContentResult(userImage.UserPhoto, "image/jpeg");
            }
            else
            {
                string fileName = HttpContext.Server.MapPath(@"..SchoolBookApplication.Data/Images/noImg.png");

                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);
                return File(imageData, "image/png");
            }
        }
    }
}
