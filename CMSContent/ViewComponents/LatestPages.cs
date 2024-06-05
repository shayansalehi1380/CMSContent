using CMSContent.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.ViewComponents
{
    public class LatestPages : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public LatestPages(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int PageCount = 9)
        {
            var pages = _context.Pages
                .Where(p => p.PageIsPublished)
                .OrderByDescending(p => p.PageDate)
                .Take(PageCount);
            return View(await pages.ToListAsync());
        }

    }
}
