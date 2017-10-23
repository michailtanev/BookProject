namespace SchoolBookApplication.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BookCategory
    {
        [Key]
        public int BookCategoryId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<BookType> Types { get; set; }
    }
}