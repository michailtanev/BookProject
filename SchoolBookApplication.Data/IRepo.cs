using SchoolBookApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBookApplication.Data
{
    public interface IRepo
    {
        IEnumerable<Book> SearchBook(string model);

    }
}
