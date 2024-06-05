using CMSContent.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSContent.ViewComponents
{
    public class PageGroups_TopNav : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public PageGroups_TopNav(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var pageGroups =
                _context.PageGroups
                .Where(pg => pg.Pages.Any())
                .OrderBy(pg => pg.PageGroupTitle);
            return View(await pageGroups.ToListAsync());
        }
    }
}
