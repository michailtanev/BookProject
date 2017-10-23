using SchoolBookApplication.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace SchoolBookApplication.Web.Controllers
{
    public class BookController : BaseController
    {
        public ActionResult BookDetails(int id)
        {
            var viewModel = this.Data.Books.All().Where(x => x.BookId == id)
                .Select(x => new BookDetailsViewModel
                {
                    BookId=x.BookId,
                    OriginalPrice=x.OriginalPrice,
                    SalePrice=x.SalePrice,
                    Year=x.Type.Year,
                    ListingDate=x.ListingDate,
                    Title = x.Type.Name,
                    Category=x.Type.BookCategory.Name,
                    ImageId = x.Image.ImageId,
                    SellerFirstName=x.Seller.Name,
                    SellerLastName = x.Seller.LastName,
                    SellerEmail = x.Seller.Email,
                    SellerPhone = x.Seller.PhoneNumber,
                    City=x.Seller.City,
                    Author=x.Author,
                    AdditionalInformation = x.AdditionalInformation
                    
                }).FirstOrDefault();

            return View(viewModel);

        }
        
        
    }
}