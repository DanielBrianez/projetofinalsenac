using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Finnova.Data.Data;
using Finnova.Core.Models;


namespace FinnovaWebApplication.Controllers
{
    public class TransferenciasController : Controller
    {
        private readonly AppDbContext _context;

        public TransferenciasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Transferencias
        public async Task<IActionResult> Index()
        {
            var finnovaWebApplicationContext = _context.Transferencia.Include(t => t.ContaDestino).Include(t => t.ContaOrigem);
            return View(await finnovaWebApplicationContext.ToListAsync());
        }

        // GET: Transferencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transferencia = await _context.Transferencia
                .Include(t => t.ContaDestino)
                .Include(t => t.ContaOrigem)
                .FirstOrDefaultAsync(m => m.IdTransferencia == id);
            if (transferencia == null)
            {
                return NotFound();
            }

            return View(transferencia);
        }

        // GET: Transferencias/Create
        public IActionResult Create()
        {
            ViewData["IdContaDestino"] = new SelectList(_context.Conta, "IdConta", "NomeConta");
            ViewData["IdContaOrigem"] = new SelectList(_context.Conta, "IdConta", "NomeConta");
            return View();
        }

        // POST: Transferencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTransferencia,Valor,DataTransferencia,IdContaOrigem,IdContaDestino,Descricao")] Transferencia transferencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transferencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdContaDestino"] = new SelectList(_context.Conta, "IdConta", "NomeConta", transferencia.IdContaDestino);
            ViewData["IdContaOrigem"] = new SelectList(_context.Conta, "IdConta", "NomeConta", transferencia.IdContaOrigem);
            return View(transferencia);
        }

        // GET: Transferencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transferencia = await _context.Transferencia.FindAsync(id);
            if (transferencia == null)
            {
                return NotFound();
            }
            ViewData["IdContaDestino"] = new SelectList(_context.Conta, "IdConta", "NomeConta", transferencia.IdContaDestino);
            ViewData["IdContaOrigem"] = new SelectList(_context.Conta, "IdConta", "NomeConta", transferencia.IdContaOrigem);
            return View(transferencia);
        }

        // POST: Transferencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTransferencia,Valor,DataTransferencia,IdContaOrigem,IdContaDestino,Descricao")] Transferencia transferencia)
        {
            if (id != transferencia.IdTransferencia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transferencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransferenciaExists(transferencia.IdTransferencia))
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
            ViewData["IdContaDestino"] = new SelectList(_context.Conta, "IdConta", "NomeConta", transferencia.IdContaDestino);
            ViewData["IdContaOrigem"] = new SelectList(_context.Conta, "IdConta", "NomeConta", transferencia.IdContaOrigem);
            return View(transferencia);
        }

        // GET: Transferencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transferencia = await _context.Transferencia
                .Include(t => t.ContaDestino)
                .Include(t => t.ContaOrigem)
                .FirstOrDefaultAsync(m => m.IdTransferencia == id);
            if (transferencia == null)
            {
                return NotFound();
            }

            return View(transferencia);
        }

        // POST: Transferencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transferencia = await _context.Transferencia.FindAsync(id);
            if (transferencia != null)
            {
                _context.Transferencia.Remove(transferencia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransferenciaExists(int id)
        {
            return _context.Transferencia.Any(e => e.IdTransferencia == id);
        }
    }
}
