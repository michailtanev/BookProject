using SchoolBookApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolBookApplication.Web.Models
{
    public class BookDetailsViewModel
    {
        public int BookId { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime ListingDate { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public string Category { get; set; }
        public int? ImageId { get; set; }
        public string SellerName { get; set; }
        public string SellerFirstName { get; set; }
        public string SellerLastName { get; set; }
        public string SellerEmail { get; set; }
        public string City { get; set; }
        public string SellerPhone { get; set; }        
        public string AdditionalInformation { get; set; }
        public string Author { get; set; }
    }
}