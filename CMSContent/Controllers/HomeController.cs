using CMSContent.Data;
using CMSContent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CMSContent.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> ShowPage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Comment comment = new Comment()
            {
                PageID = (int)id,
            };

            return View(comment);
        }

        public async Task<IActionResult> ShowPages(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pagegroup = _context.PageGroups.FirstOrDefault(pg => pg.PageGroupID == id);
            ViewBag.PageGroupTitle = pagegroup.PageGroupTitle;
            var pages = _context.Pages.Include(p => p.PageGroup).Where(p => p.PageGroupID == id);
            return View(await pages.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> ShowPages(Comment comment)
        {
            if(ModelState.IsValid)
            {
                comment.CommentDate = DateTime.Now;
                _context.Comments.Add(comment);
                _context.SaveChanges();
                //return RedirectToAction("ShowPage", new { id = comment.PageID });
                return Redirect(Url.RouteUrl(new { controller = "Home", action = "ShowPage", id = comment.PageID }) + "#comment" + comment.CommentID);
            }
            return View(comment);
        }
    }
}
