using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBookApplication.Data
{
    class Repo : IRepo
    {
        public IEnumerable<Domain.Book> SearchBook(string model)
        {
            using (var con = new SchoolBookDbContext())
            {
                var booklist = con.Books.Where(x => x.Type.Equals(model));
                return booklist;
            }
        }
    }
}
