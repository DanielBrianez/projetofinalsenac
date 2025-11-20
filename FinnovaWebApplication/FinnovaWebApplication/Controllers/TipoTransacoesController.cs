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
    public class TipoTransacoesController : Controller
    {
        private readonly FinnovaWebApplicationContext _context;

        public TipoTransacoesController(FinnovaWebApplicationContext context)
        {
            _context = context;
        }

        // GET: TipoTransacoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoTransacao.ToListAsync());
        }

        // GET: TipoTransacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTransacao = await _context.TipoTransacao
                .FirstOrDefaultAsync(m => m.IdTipoTransacao == id);
            if (tipoTransacao == null)
            {
                return NotFound();
            }

            return View(tipoTransacao);
        }

        // GET: TipoTransacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoTransacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoTransacao,DescricaoTipoTransacao")] TipoTransacao tipoTransacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoTransacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoTransacao);
        }

        // GET: TipoTransacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTransacao = await _context.TipoTransacao.FindAsync(id);
            if (tipoTransacao == null)
            {
                return NotFound();
            }
            return View(tipoTransacao);
        }

        // POST: TipoTransacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoTransacao,DescricaoTipoTransacao")] TipoTransacao tipoTransacao)
        {
            if (id != tipoTransacao.IdTipoTransacao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoTransacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoTransacaoExists(tipoTransacao.IdTipoTransacao))
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
            return View(tipoTransacao);
        }

        // GET: TipoTransacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTransacao = await _context.TipoTransacao
                .FirstOrDefaultAsync(m => m.IdTipoTransacao == id);
            if (tipoTransacao == null)
            {
                return NotFound();
            }

            return View(tipoTransacao);
        }

        // POST: TipoTransacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoTransacao = await _context.TipoTransacao.FindAsync(id);
            if (tipoTransacao != null)
            {
                _context.TipoTransacao.Remove(tipoTransacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoTransacaoExists(int id)
        {
            return _context.TipoTransacao.Any(e => e.IdTipoTransacao == id);
        }
    }
}
