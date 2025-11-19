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
    public class TransacoesController : Controller
    {
        private readonly FinnovaWebApplicationContext _context;

        public TransacoesController(FinnovaWebApplicationContext context)
        {
            _context = context;
        }

        // GET: Transacoes
        public async Task<IActionResult> Index()
        {
            var finnovaWebApplicationContext = _context.Transacao.Include(t => t.Categoria).Include(t => t.Conta).Include(t => t.Subcategoria).Include(t => t.TipoTransacao).Include(t => t.Usuario);
            return View(await finnovaWebApplicationContext.ToListAsync());
        }

        // GET: Transacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacao = await _context.Transacao
                .Include(t => t.Categoria)
                .Include(t => t.Conta)
                .Include(t => t.Subcategoria)
                .Include(t => t.TipoTransacao)
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.IdTransacao == id);
            if (transacao == null)
            {
                return NotFound();
            }

            return View(transacao);
        }

        // GET: Transacoes/Create
        public IActionResult Create()
        {
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "Nome");
            ViewData["IdConta"] = new SelectList(_context.Conta, "IdConta", "NomeConta");
            ViewData["IdSubcategoria"] = new SelectList(_context.Subcategoria, "IdSubcategoria", "Nome");
            ViewData["IdTipoTransacao"] = new SelectList(_context.TipoTransacao, "IdTipoTransacao", "DescricaoTipoTransacao");
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Email");
            return View();
        }

        // POST: Transacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTransacao,Valor,DataTransacao,IdTipoTransacao,IdUsuario,IdConta,IdCategoria,IdSubcategoria,Descricao,CriadoEm,AtualizadoEm")] Transacao transacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "Nome", transacao.IdCategoria);
            ViewData["IdConta"] = new SelectList(_context.Conta, "IdConta", "NomeConta", transacao.IdConta);
            ViewData["IdSubcategoria"] = new SelectList(_context.Subcategoria, "IdSubcategoria", "Nome", transacao.IdSubcategoria);
            ViewData["IdTipoTransacao"] = new SelectList(_context.TipoTransacao, "IdTipoTransacao", "DescricaoTipoTransacao", transacao.IdTipoTransacao);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Email", transacao.IdUsuario);
            return View(transacao);
        }

        // GET: Transacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacao = await _context.Transacao.FindAsync(id);
            if (transacao == null)
            {
                return NotFound();
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "Nome", transacao.IdCategoria);
            ViewData["IdConta"] = new SelectList(_context.Conta, "IdConta", "NomeConta", transacao.IdConta);
            ViewData["IdSubcategoria"] = new SelectList(_context.Subcategoria, "IdSubcategoria", "Nome", transacao.IdSubcategoria);
            ViewData["IdTipoTransacao"] = new SelectList(_context.TipoTransacao, "IdTipoTransacao", "DescricaoTipoTransacao", transacao.IdTipoTransacao);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Email", transacao.IdUsuario);
            return View(transacao);
        }

        // POST: Transacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTransacao,Valor,DataTransacao,IdTipoTransacao,IdUsuario,IdConta,IdCategoria,IdSubcategoria,Descricao,CriadoEm,AtualizadoEm")] Transacao transacao)
        {
            if (id != transacao.IdTransacao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransacaoExists(transacao.IdTransacao))
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
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "Nome", transacao.IdCategoria);
            ViewData["IdConta"] = new SelectList(_context.Conta, "IdConta", "NomeConta", transacao.IdConta);
            ViewData["IdSubcategoria"] = new SelectList(_context.Subcategoria, "IdSubcategoria", "Nome", transacao.IdSubcategoria);
            ViewData["IdTipoTransacao"] = new SelectList(_context.TipoTransacao, "IdTipoTransacao", "DescricaoTipoTransacao", transacao.IdTipoTransacao);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Email", transacao.IdUsuario);
            return View(transacao);
        }

        // GET: Transacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacao = await _context.Transacao
                .Include(t => t.Categoria)
                .Include(t => t.Conta)
                .Include(t => t.Subcategoria)
                .Include(t => t.TipoTransacao)
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.IdTransacao == id);
            if (transacao == null)
            {
                return NotFound();
            }

            return View(transacao);
        }

        // POST: Transacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transacao = await _context.Transacao.FindAsync(id);
            if (transacao != null)
            {
                _context.Transacao.Remove(transacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransacaoExists(int id)
        {
            return _context.Transacao.Any(e => e.IdTransacao == id);
        }
    }
}
