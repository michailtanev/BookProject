    namespace SchoolBookApplication.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;


    public class Book
    {
        [Key]

        public int BookId { get; set; }

        public decimal OriginalPrice { get; set; }
        public decimal SalePrice { get; set; }

        public DateTime ListingDate { get; set; }

        public string SellerId { get; set; }
        public virtual User Seller { get; set; }

        public int BookTypeId { get; set; }
        public virtual BookType Type { get; set; }

        public int? ImageId { get; set; }
        public virtual Image Image { get; set; }

        public string Author { get; set; }
        public string AdditionalInformation { get; set; }

        
    }
}