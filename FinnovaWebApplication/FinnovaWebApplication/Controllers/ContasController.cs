using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Finnova.Core.Models;
using FinnovaWebApplication.Data;

namespace FinnovaWebApplication.Controllers
{
    public class ContasController : Controller
    {
        private readonly FinnovaWebApplicationContext _context;

        public ContasController(FinnovaWebApplicationContext context)
        {
            _context = context;
        }

        // GET: Contas
        public async Task<IActionResult> Index()
        {
            var finnovaWebApplicationContext = _context.Conta.Include(c => c.Banco).Include(c => c.Usuario);
            return View(await finnovaWebApplicationContext.ToListAsync());
        }

        // GET: Contas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conta = await _context.Conta
                .Include(c => c.Banco)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.IdConta == id);
            if (conta == null)
            {
                return NotFound();
            }

            return View(conta);
        }

        // GET: Contas/Create
        public IActionResult Create()
        {
            ViewData["IdBanco"] = new SelectList(_context.Banco, "IdBanco", "Codigo");
            ViewData["IdUsuario"] = new SelectList(_context.Set<Usuario>(), "IdUsuario", "Email");
            return View();
        }

        // POST: Contas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConta,IdUsuario,IdBanco,NomeConta,Tipo,SaldoInicial,SaldoAtual,DataCriacao,DataAtualizacao,Ativo")] Conta conta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBanco"] = new SelectList(_context.Banco, "IdBanco", "Codigo", conta.IdBanco);
            ViewData["IdUsuario"] = new SelectList(_context.Set<Usuario>(), "IdUsuario", "Email", conta.IdUsuario);
            return View(conta);
        }

        // GET: Contas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conta = await _context.Conta.FindAsync(id);
            if (conta == null)
            {
                return NotFound();
            }
            ViewData["IdBanco"] = new SelectList(_context.Banco, "IdBanco", "Codigo", conta.IdBanco);
            ViewData["IdUsuario"] = new SelectList(_context.Set<Usuario>(), "IdUsuario", "Email", conta.IdUsuario);
            return View(conta);
        }

        // POST: Contas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConta,IdUsuario,IdBanco,NomeConta,Tipo,SaldoInicial,SaldoAtual,DataCriacao,DataAtualizacao,Ativo")] Conta conta)
        {
            if (id != conta.IdConta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaExists(conta.IdConta))
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
            ViewData["IdBanco"] = new SelectList(_context.Banco, "IdBanco", "Codigo", conta.IdBanco);
            ViewData["IdUsuario"] = new SelectList(_context.Set<Usuario>(), "IdUsuario", "Email", conta.IdUsuario);
            return View(conta);
        }

        // GET: Contas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conta = await _context.Conta
                .Include(c => c.Banco)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.IdConta == id);
            if (conta == null)
            {
                return NotFound();
            }

            return View(conta);
        }

        // POST: Contas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conta = await _context.Conta.FindAsync(id);
            if (conta != null)
            {
                _context.Conta.Remove(conta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContaExists(int id)
        {
            return _context.Conta.Any(e => e.IdConta == id);
        }
    }
}
