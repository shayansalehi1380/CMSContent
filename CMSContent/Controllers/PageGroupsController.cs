using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMSContent.Data;
using CMSContent.Models;
using Microsoft.AspNetCore.Authorization;

namespace CMSContent.Controllers
{
    [Authorize]
    public class PageGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PageGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PageGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.PageGroups.ToListAsync());
        }

        // GET: PageGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageGroup = await _context.PageGroups
                .FirstOrDefaultAsync(m => m.PageGroupID == id);
            if (pageGroup == null)
            {
                return NotFound();
            }

            return View(pageGroup);
        }

        // GET: PageGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PageGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PageGroupID,PageGroupTitle")] PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pageGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pageGroup);
        }

        // GET: PageGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageGroup = await _context.PageGroups.FindAsync(id);
            if (pageGroup == null)
            {
                return NotFound();
            }
            return View(pageGroup);
        }

        // POST: PageGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PageGroupID,PageGroupTitle")] PageGroup pageGroup)
        {
            if (id != pageGroup.PageGroupID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pageGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageGroupExists(pageGroup.PageGroupID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pageGroup);
        }

        // GET: PageGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageGroup = await _context.PageGroups
                .FirstOrDefaultAsync(m => m.PageGroupID == id);
            if (pageGroup == null)
            {
                return NotFound();
            }

            return View(pageGroup);
        }

        // POST: PageGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pageGroup = await _context.PageGroups.FindAsync(id);
            _context.PageGroups.Remove(pageGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PageGroupExists(int id)
        {
            return _context.PageGroups.Any(e => e.PageGroupID == id);
        }
    }
}
