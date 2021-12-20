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
    public class ClassePromoesController : Controller
    {
        private readonly Context _context;

        public ClassePromoesController(Context context)
        {
            _context = context;
        }

        // GET: ClassePromoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.classepromo.ToListAsync());
        }

        // GET: ClassePromoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classePromo = await _context.classepromo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classePromo == null)
            {
                return NotFound();
            }

            return View(classePromo);
        }

        // GET: ClassePromoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassePromoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Pacote,Destinos,Regiao,Preco,Desconto")] ClassePromo classePromo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classePromo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classePromo);
        }

        // GET: ClassePromoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classePromo = await _context.classepromo.FindAsync(id);
            if (classePromo == null)
            {
                return NotFound();
            }
            return View(classePromo);
        }

        // POST: ClassePromoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Pacote,Destinos,Regiao,Preco,Desconto")] ClassePromo classePromo)
        {
            if (id != classePromo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classePromo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassePromoExists(classePromo.Id))
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
            return View(classePromo);
        }

        // GET: ClassePromoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classePromo = await _context.classepromo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classePromo == null)
            {
                return NotFound();
            }

            return View(classePromo);
        }

        // POST: ClassePromoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classePromo = await _context.classepromo.FindAsync(id);
            _context.classepromo.Remove(classePromo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassePromoExists(int id)
        {
            return _context.classepromo.Any(e => e.Id == id);
        }
    }
}
