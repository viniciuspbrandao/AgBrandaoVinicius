#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgBrandaoVinicius.Models;

namespace AgBrandaoVinicius.Controllers
{
    public class ClasseDestinosController : Controller
    {
        private readonly Context _context;

        public ClasseDestinosController(Context context)
        {
            _context = context;
        }

        // GET: ClasseDestinos
        public async Task<IActionResult> Index()
        {
            return View(await _context.classedestinos.ToListAsync());
        }

        // GET: ClasseDestinos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classeDestinos = await _context.classedestinos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classeDestinos == null)
            {
                return NotFound();
            }

            return View(classeDestinos);
        }

        // GET: ClasseDestinos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClasseDestinos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Pacote,Destino,Regiao,Preco")] ClasseDestinos classeDestinos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classeDestinos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classeDestinos);
        }

        // GET: ClasseDestinos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classeDestinos = await _context.classedestinos.FindAsync(id);
            if (classeDestinos == null)
            {
                return NotFound();
            }
            return View(classeDestinos);
        }

        // POST: ClasseDestinos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Pacote,Destino,Regiao,Preco")] ClasseDestinos classeDestinos)
        {
            if (id != classeDestinos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classeDestinos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasseDestinosExists(classeDestinos.Id))
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
            return View(classeDestinos);
        }

        // GET: ClasseDestinos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classeDestinos = await _context.classedestinos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classeDestinos == null)
            {
                return NotFound();
            }

            return View(classeDestinos);
        }

        // POST: ClasseDestinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classeDestinos = await _context.classedestinos.FindAsync(id);
            _context.classedestinos.Remove(classeDestinos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasseDestinosExists(int id)
        {
            return _context.classedestinos.Any(e => e.Id == id);
        }
    }
}
