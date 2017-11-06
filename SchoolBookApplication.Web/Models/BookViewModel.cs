using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolBookApplication.Web.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public decimal? Price { get; set; }

        public decimal? OriginalPrice { get; set; }
        public decimal? SalePrice { get; set; }
        
        public DateTime ListingDate { get; set; }

        public string Type { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int? ImageId { get; set; }
        public string SellerFirstName { get; set; }
        public string SellerLastName { get; set; }

    }
}