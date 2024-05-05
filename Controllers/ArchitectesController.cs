using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamanApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ExamanApp.Controllers
{
    [Authorize]
    public class ArchitectesController : Controller
    {
        private readonly Context _context;

        public ArchitectesController(Context context)
        {
            _context = context;
        }

        // GET: Architectes
        public async Task<IActionResult> Index()
        {
              return _context.Architecte != null ? 
                          View(await _context.Architecte.ToListAsync()) :
                          Problem("Entity set 'Context.Architecte'  is null.");
        }

        // GET: Architectes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Architecte == null)
            {
                return NotFound();
            }

            var architecte = await _context.Architecte
                .FirstOrDefaultAsync(m => m.ArchitecteId == id);
            if (architecte == null)
            {
                return NotFound();
            }

            return View(architecte);
        }

        // GET: Architectes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Architectes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Architecte architecte)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_context.Architecte.Where(x => x.NomArchitecte == architecte.NomArchitecte).Count() > 0)
                    {

                        ViewBag.error = "Architecte already exists";
                        return View(architecte);
                    }
                    _context.Architecte.Add(architecte);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Architectes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Architecte == null)
            {
                return NotFound();
            }

            var architecte = await _context.Architecte.FindAsync(id);
            if (architecte == null)
            {
                return NotFound();
            }
            return View(architecte);
        }

        // POST: Architectes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArchitecteId,NomArchitecte,prenomArchitecte,telephone")] Architecte architecte)
        {
            if (id != architecte.ArchitecteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(architecte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArchitecteExists(architecte.ArchitecteId))
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
            return View(architecte);
        }

        // GET: Architectes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Architecte == null)
            {
                return NotFound();
            }

            var architecte = await _context.Architecte
                .FirstOrDefaultAsync(m => m.ArchitecteId == id);
            if (architecte == null)
            {
                return NotFound();
            }

            return View(architecte);
        }

        // POST: Architectes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Architecte == null)
            {
                return Problem("Entity set 'Context.Architecte'  is null.");
            }
            var architecte = await _context.Architecte.FindAsync(id);
            if (architecte != null)
            {
                _context.Architecte.Remove(architecte);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArchitecteExists(int id)
        {
          return (_context.Architecte?.Any(e => e.ArchitecteId == id)).GetValueOrDefault();
        }
    }
}
