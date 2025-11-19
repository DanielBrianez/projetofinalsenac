using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinnovaWebApplication.Data;
using FinnovaWebApplication.Models;

namespace FinnovaWebApplication.Controllers
{
    public class SubcategoriasController : Controller
    {
        private readonly FinnovaWebApplicationContext _context;

        public SubcategoriasController(FinnovaWebApplicationContext context)
        {
            _context = context;
        }

        // GET: Subcategorias
        public async Task<IActionResult> Index()
        {
            var finnovaWebApplicationContext = _context.Subcategoria.Include(s => s.Categoria);
            return View(await finnovaWebApplicationContext.ToListAsync());
        }

        // GET: Subcategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategoria = await _context.Subcategoria
                .Include(s => s.Categoria)
                .FirstOrDefaultAsync(m => m.IdSubcategoria == id);
            if (subcategoria == null)
            {
                return NotFound();
            }

            return View(subcategoria);
        }

        // GET: Subcategorias/Create
        public IActionResult Create()
        {
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "Nome");
            return View();
        }

        // POST: Subcategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSubcategoria,Nome,IdCategoria")] Subcategoria subcategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subcategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "Nome", subcategoria.IdCategoria);
            return View(subcategoria);
        }

        // GET: Subcategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategoria = await _context.Subcategoria.FindAsync(id);
            if (subcategoria == null)
            {
                return NotFound();
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "Nome", subcategoria.IdCategoria);
            return View(subcategoria);
        }

        // POST: Subcategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSubcategoria,Nome,IdCategoria")] Subcategoria subcategoria)
        {
            if (id != subcategoria.IdSubcategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subcategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubcategoriaExists(subcategoria.IdSubcategoria))
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
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "Nome", subcategoria.IdCategoria);
            return View(subcategoria);
        }

        // GET: Subcategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategoria = await _context.Subcategoria
                .Include(s => s.Categoria)
                .FirstOrDefaultAsync(m => m.IdSubcategoria == id);
            if (subcategoria == null)
            {
                return NotFound();
            }

            return View(subcategoria);
        }

        // POST: Subcategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subcategoria = await _context.Subcategoria.FindAsync(id);
            if (subcategoria != null)
            {
                _context.Subcategoria.Remove(subcategoria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubcategoriaExists(int id)
        {
            return _context.Subcategoria.Any(e => e.IdSubcategoria == id);
        }
    }
}
