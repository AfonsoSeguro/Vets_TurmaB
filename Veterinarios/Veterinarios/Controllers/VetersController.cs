using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Veterinarios.Data;
using Veterinarios.Models;

namespace Veterinarios.Controllers
{
    public class VetersController : Controller
    {
        private readonly VetsBD _context;

        public VetersController(VetsBD context)
        {
            _context = context;
        }

        // GET: Veters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Veterinarios.ToListAsync());
        }

        // GET: Veters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veter = await _context.Veterinarios
                .FirstOrDefaultAsync(m => m.ID == id);
            if (veter == null)
            {
                return NotFound();
            }

            return View(veter);
        }

        // GET: Veters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Veters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,nome,nCelula,foto")] Veter veter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veter);
        }

        // GET: Veters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veter = await _context.Veterinarios.FindAsync(id);
            if (veter == null)
            {
                return NotFound();
            }
            return View(veter);
        }

        // POST: Veters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,nome,nCelula,foto")] Veter veter)
        {
            if (id != veter.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeterExists(veter.ID))
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
            return View(veter);
        }

        // GET: Veters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veter = await _context.Veterinarios
                .FirstOrDefaultAsync(m => m.ID == id);
            if (veter == null)
            {
                return NotFound();
            }

            return View(veter);
        }

        // POST: Veters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veter = await _context.Veterinarios.FindAsync(id);
            _context.Veterinarios.Remove(veter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeterExists(int id)
        {
            return _context.Veterinarios.Any(e => e.ID == id);
        }
    }
}
