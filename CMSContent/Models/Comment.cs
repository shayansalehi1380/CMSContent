using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;

namespace CMSContent.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        [Display(Name = "صفحه")]
        public int PageID { get; set; }

        [Display(Name = "نام نویسنده")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        [StringLength(60, ErrorMessage = "طول {0} میبایست بین {2} تا {1} کاراکتر باشد", MinimumLength = 8)]
        public string AuthorName { get; set; }

        [Display(Name = "ایمیل نویسنده")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "مقدار وارد شده برای {0} شبیه یک آدرس ایمیل نیست")]
        [StringLength(250, ErrorMessage = "طول {0} میبایست بین {2} تا {1} کاراکتر باشد", MinimumLength = 15)]
        public string AuthorEmail { get; set; }

        [Display(Name = "متن نظر")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        public string CommentText { get; set; }

        [Display(Name = "تاریخ ثبت نظر")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        public DateTime CommentDate { get; set; }

        // Navigation Properties
        [ForeignKey("PageID")]
        [Display(Name = "صفحه")]
        public virtual Page Page { get; set; }
    }
}
