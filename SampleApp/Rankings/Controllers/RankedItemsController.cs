using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rankings.Db;
using Rankings.Models;

namespace Rankings.Controllers
{
    public class RankedItemsController : Controller
    {
        private readonly RankingsContext _context;

        public RankedItemsController(RankingsContext context)
        {
            _context = context;
        }

        // GET: RankedItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.RankedItem.ToListAsync());
        }

        // GET: RankedItems/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rankedItem = await _context.RankedItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rankedItem == null)
            {
                return NotFound();
            }

            return View(rankedItem);
        }

        // GET: RankedItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RankedItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,EloNumber")] RankedItem rankedItem)
        {
            if (ModelState.IsValid)
            {
                rankedItem.Id = Guid.NewGuid();
                _context.Add(rankedItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rankedItem);
        }

        // GET: RankedItems/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rankedItem = await _context.RankedItem.FindAsync(id);
            if (rankedItem == null)
            {
                return NotFound();
            }
            return View(rankedItem);
        }

        // POST: RankedItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,EloNumber")] RankedItem rankedItem)
        {
            if (id != rankedItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rankedItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RankedItemExists(rankedItem.Id))
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
            return View(rankedItem);
        }

        // GET: RankedItems/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rankedItem = await _context.RankedItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rankedItem == null)
            {
                return NotFound();
            }

            return View(rankedItem);
        }

        // POST: RankedItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var rankedItem = await _context.RankedItem.FindAsync(id);
            _context.RankedItem.Remove(rankedItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RankedItemExists(Guid id)
        {
            return _context.RankedItem.Any(e => e.Id == id);
        }
    }
}
