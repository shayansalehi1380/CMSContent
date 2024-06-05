using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSContent.Models
{
    public class Page
    {
        [Key]
        public int PageID { get; set; }

        [Display(Name = "گروه صفحه")]
        public int PageGroupID { get; set; }

        [Display(Name = "عنوان صفحه")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        [StringLength(500, ErrorMessage = "طول {0} میبایست بین {2} تا {1} کاراکتر باشد", MinimumLength = 8)]
        public string PageTitle { get; set; }

        [Display(Name = "متن کوتاه صفحه")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        [StringLength(3000, ErrorMessage = "طول {0} میبایست بین {2} تا {1} کاراکتر باشد", MinimumLength = 8)]
        [DataType(DataType.MultilineText)]
        public string PageShortText { get; set; }

        [Display(Name = "متن کامل صفحه")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string PageText { get; set; }

        [Display(Name = "تاریخ صفحه")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime PageDate { get; set; }

        [Display(Name = "منتشر شده؟")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        public bool PageIsPublished { get; set; }

        // Navigation Properties
        [ForeignKey("PageGroupID")]
        [Display(Name = "گروه صفحه")]
        public virtual PageGroup PageGroup { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
