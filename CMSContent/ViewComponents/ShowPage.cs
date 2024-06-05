using CMSContent.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CMSContent.ViewComponents
{
    public class ShowPage : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ShowPage(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? PageID)
        {

            var page = await _context.Pages
                .Include(p => p.PageGroup)
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(m => m.PageID == PageID);

            return View(page);
        }
    }
}
