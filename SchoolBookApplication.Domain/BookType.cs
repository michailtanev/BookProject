namespace SchoolBookApplication.Domain
{

    using System.ComponentModel.DataAnnotations;

    public class BookType
    {
        [Key]

        public int BookTypeId { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }
        
        public int BookCategoryId { get; set; }
        
        public virtual BookCategory BookCategory { get; set; }
    }
}