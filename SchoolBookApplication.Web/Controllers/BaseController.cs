using SchoolBookApplication.Data;
using System.Web.Mvc;

namespace SchoolBookApplication.Web.Controllers
{
    public class BaseController : Controller
    {
        protected ISchoolBookData Data;
        protected IRepo SearchData;

        public BaseController(ISchoolBookData data)
        {
            this.Data = data;
        }
        public BaseController(IRepo data)
        {
            this.SearchData = data;
        }

        public BaseController()
            : this(new SchoolBookData())
        {
        }
    }
}