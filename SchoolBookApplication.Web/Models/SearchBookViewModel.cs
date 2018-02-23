using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolBookApplication.Web.Models
{
    public class SearchBookViewModel
    {
        [Display(Name = "Book")]
        public string BookType { get; set; }
    }
}