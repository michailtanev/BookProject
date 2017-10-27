using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolBookApplication.Web.Models
{
    public class CreateBookViewModel
    {
        [Required]
        [Range(0, 9999)]
        [Display(Name = "Original Price")]
        public decimal? OriginaPrice { get; set; }

        [Required]
        [Range(0, 9999)]
        [Display(Name = "Sale Price")]
        public decimal? SalePrice { get; set; }

        [Required]
        [StringLength(25)]
        public string Category { get; set; }

        [Required]
        [StringLength(25)]
        public string Title { get; set; }

        [Required]
        [Range(2000,2017)]
        public int? Year { get; set; }

        [Required]
        [Display(Name = "Upload Photo")]
        public HttpPostedFileBase UploadPhoto { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Condition")]
        public string AdditionalInformation { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Author")]
        public string Author { get; set; }
    }
}