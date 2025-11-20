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
    public class TipoInvestimentoesController : Controller
    {
        private readonly FinnovaWebApplicationContext _context;

        public TipoInvestimentoesController(FinnovaWebApplicationContext context)
        {
            _context = context;
        }

        // GET: TipoInvestimentoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoInvestimento.ToListAsync());
        }

        // GET: TipoInvestimentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoInvestimento = await _context.TipoInvestimento
                .FirstOrDefaultAsync(m => m.IdTipoInvestimento == id);
            if (tipoInvestimento == null)
            {
                return NotFound();
            }

            return View(tipoInvestimento);
        }

        // GET: TipoInvestimentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoInvestimentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoInvestimento,DescricaoTipoInvestimento")] TipoInvestimento tipoInvestimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoInvestimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoInvestimento);
        }

        // GET: TipoInvestimentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoInvestimento = await _context.TipoInvestimento.FindAsync(id);
            if (tipoInvestimento == null)
            {
                return NotFound();
            }
            return View(tipoInvestimento);
        }

        // POST: TipoInvestimentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoInvestimento,DescricaoTipoInvestimento")] TipoInvestimento tipoInvestimento)
        {
            if (id != tipoInvestimento.IdTipoInvestimento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoInvestimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoInvestimentoExists(tipoInvestimento.IdTipoInvestimento))
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
            return View(tipoInvestimento);
        }

        // GET: TipoInvestimentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoInvestimento = await _context.TipoInvestimento
                .FirstOrDefaultAsync(m => m.IdTipoInvestimento == id);
            if (tipoInvestimento == null)
            {
                return NotFound();
            }

            return View(tipoInvestimento);
        }

        // POST: TipoInvestimentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoInvestimento = await _context.TipoInvestimento.FindAsync(id);
            if (tipoInvestimento != null)
            {
                _context.TipoInvestimento.Remove(tipoInvestimento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoInvestimentoExists(int id)
        {
            return _context.TipoInvestimento.Any(e => e.IdTipoInvestimento == id);
        }
    }
}
