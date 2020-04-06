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
    public class DonosController : Controller{
        private readonly VetsBD bd;

        public DonosController(VetsBD context){
            bd = context;
        }

        // GET: Donos
        public async Task<IActionResult> Index(){
            return View(await bd.Donos.ToListAsync());
        }

        // GET: Donos/Details/5
        public async Task<IActionResult> Details(int? id){
            if (id == null){
                return NotFound();
            }

            var donos = await bd.Donos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (donos == null){
                return NotFound();
            }

            return View(donos);
        }

        // GET: Donos/Create
        public IActionResult Create(){
            return View();
        }

        // POST: Donos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,nome,NIF")] Donos donos){
            if (ModelState.IsValid){
                bd.Add(donos);
                await bd.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donos);
        }

        // GET: Donos/Edit/5
        public async Task<IActionResult> Edit(int? id){
            if (id == null){
                return NotFound();
            }

            var donos = await bd.Donos.FindAsync(id);
            if (donos == null){
                return NotFound();
            }
            return View(donos);
        }

        // POST: Donos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,nome,NIF")] Donos donos){
            if (id != donos.ID){
                return NotFound();
            }

            if (ModelState.IsValid){
                try{
                    bd.Update(donos);
                    await bd.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException){
                    if (!DonosExists(donos.ID)){
                        return NotFound();
                    }
                    else{
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(donos);
        }

        // GET: Donos/Delete/5
        public async Task<IActionResult> Delete(int? id){
            if (id == null){
                return NotFound();
            }

            var donos = await bd.Donos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (donos == null){
                return NotFound();
            }

            return View(donos);
        }

        // POST: Donos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id){
            var donos = await bd.Donos.FindAsync(id);
            bd.Donos.Remove(donos);
            await bd.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonosExists(int id){
            return bd.Donos.Any(e => e.ID == id);
        }
    }
}
