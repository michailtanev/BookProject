using System.Data.Entity;
using SchoolBookApplication.Domain;

namespace SchoolBookApplication.Data
{
    public interface ISchoolBookData
    {
        IRepository<Book> Books { get; }
        IRepository<BookType> BookTypes { get; }
        IRepository<BookCategory> BookCategories { get; }
        DbContext Context { get; }
        IRepository<Image> Images { get; }
        IRepository<User> Users { get; }

        void Dispose();
        int SaveChanges();
    }
}