using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSContent.Models
{
    public class PageGroup
    {
        [Key]
        public int PageGroupID { get; set; }

        [Display(Name = "گروه صفحه")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        [StringLength(100, ErrorMessage = "طول {0} میبایست بین {2} تا {1} کاراکتر باشد", MinimumLength = 5)]
        public string PageGroupTitle { get; set; }

        // Navigation Properties
        public virtual List<Page> Pages { get; set; }
    }
}
