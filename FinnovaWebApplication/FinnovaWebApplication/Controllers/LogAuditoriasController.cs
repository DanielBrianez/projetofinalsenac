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
    public class LogAuditoriasController : Controller
    {
        private readonly FinnovaWebApplicationContext _context;

        public LogAuditoriasController(FinnovaWebApplicationContext context)
        {
            _context = context;
        }

        // GET: LogAuditorias
        public async Task<IActionResult> Index()
        {
            var finnovaWebApplicationContext = _context.LogAuditoria.Include(l => l.Usuario);
            return View(await finnovaWebApplicationContext.ToListAsync());
        }

        // GET: LogAuditorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logAuditoria = await _context.LogAuditoria
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.IdLog == id);
            if (logAuditoria == null)
            {
                return NotFound();
            }

            return View(logAuditoria);
        }

        // GET: LogAuditorias/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Email");
            return View();
        }

        // POST: LogAuditorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLog,IdUsuario,DataHora,Entidade,Acao,EntidadeId,ValorAntigo,ValorNovo,IP,UserAgent")] LogAuditoria logAuditoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logAuditoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Email", logAuditoria.IdUsuario);
            return View(logAuditoria);
        }

        // GET: LogAuditorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logAuditoria = await _context.LogAuditoria.FindAsync(id);
            if (logAuditoria == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Email", logAuditoria.IdUsuario);
            return View(logAuditoria);
        }

        // POST: LogAuditorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLog,IdUsuario,DataHora,Entidade,Acao,EntidadeId,ValorAntigo,ValorNovo,IP,UserAgent")] LogAuditoria logAuditoria)
        {
            if (id != logAuditoria.IdLog)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logAuditoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogAuditoriaExists(logAuditoria.IdLog))
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
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Email", logAuditoria.IdUsuario);
            return View(logAuditoria);
        }

        // GET: LogAuditorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logAuditoria = await _context.LogAuditoria
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.IdLog == id);
            if (logAuditoria == null)
            {
                return NotFound();
            }

            return View(logAuditoria);
        }

        // POST: LogAuditorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var logAuditoria = await _context.LogAuditoria.FindAsync(id);
            if (logAuditoria != null)
            {
                _context.LogAuditoria.Remove(logAuditoria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogAuditoriaExists(int id)
        {
            return _context.LogAuditoria.Any(e => e.IdLog == id);
        }
    }
}
