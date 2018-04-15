using Microsoft.AspNet.Identity.EntityFramework;
using SchoolBookApplication.Domain;
using System.Data.Entity;

namespace SchoolBookApplication.Data
{
    public class SchoolBookDbContext : IdentityDbContext<User>
    {
        public SchoolBookDbContext() : base("DefaultConnection", throwIfV1Schema:false)
        {
        }

        public virtual IDbSet<Book> Books { get; set; }
        public virtual IDbSet<BookCategory> BookCategories { get; set; }
        public virtual IDbSet<BookType> BookTypes { get; set; }
        public virtual IDbSet<Image> Images { get; set; }

        public static SchoolBookDbContext Create()
        {
            return new SchoolBookDbContext();
        }
    }

}
