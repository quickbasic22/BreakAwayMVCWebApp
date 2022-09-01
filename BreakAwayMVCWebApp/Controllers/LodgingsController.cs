using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BreakAwayMVCWebApp.Data;
using BreakAwayMVCWebApp.Models;

namespace BreakAwayMVCWebApp.Controllers
{
    public class LodgingsController : Controller
    {
        private readonly BreakAwayContext _context;

        public LodgingsController(BreakAwayContext context)
        {
            _context = context;
        }

        // GET: Lodgings
        public async Task<IActionResult> Index()
        {
            var breakAwayContext = _context.Lodging.Include(l => l.LodgingDestination);
            return View(await breakAwayContext.ToListAsync());
        }

        // GET: Lodgings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lodging == null)
            {
                return NotFound();
            }

            var lodging = await _context.Lodging
                .Include(l => l.LodgingDestination)
                .FirstOrDefaultAsync(m => m.LodgingId == id);
            if (lodging == null)
            {
                return NotFound();
            }

            return View(lodging);
        }

        // GET: Lodgings/Create
        public IActionResult Create()
        {
            ViewData["LodgingDestinationId"] = new SelectList(_context.Destination, "DestinationId", "DestinationId");
            return View();
        }

        // POST: Lodgings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LodgingId,LodgingName,Owner,IsResort,LodgingDestinationId")] Lodging lodging)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lodging);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LodgingDestinationId"] = new SelectList(_context.Destination, "DestinationId", "DestinationId", lodging.LodgingDestinationId);
            return View(lodging);
        }

        // GET: Lodgings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lodging == null)
            {
                return NotFound();
            }

            var lodging = await _context.Lodging.FindAsync(id);
            if (lodging == null)
            {
                return NotFound();
            }
            ViewData["LodgingDestinationId"] = new SelectList(_context.Destination, "DestinationId", "DestinationId", lodging.LodgingDestinationId);
            return View(lodging);
        }

        // POST: Lodgings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LodgingId,LodgingName,Owner,IsResort,LodgingDestinationId")] Lodging lodging)
        {
            if (id != lodging.LodgingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lodging);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LodgingExists(lodging.LodgingId))
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
            ViewData["LodgingDestinationId"] = new SelectList(_context.Destination, "DestinationId", "DestinationId", lodging.LodgingDestinationId);
            return View(lodging);
        }

        // GET: Lodgings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lodging == null)
            {
                return NotFound();
            }

            var lodging = await _context.Lodging
                .Include(l => l.LodgingDestination)
                .FirstOrDefaultAsync(m => m.LodgingId == id);
            if (lodging == null)
            {
                return NotFound();
            }

            return View(lodging);
        }

        // POST: Lodgings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lodging == null)
            {
                return Problem("Entity set 'BreakAwayContext.Lodging'  is null.");
            }
            var lodging = await _context.Lodging.FindAsync(id);
            if (lodging != null)
            {
                _context.Lodging.Remove(lodging);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LodgingExists(int id)
        {
          return (_context.Lodging?.Any(e => e.LodgingId == id)).GetValueOrDefault();
        }
    }
}
