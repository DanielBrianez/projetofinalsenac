using Finnova.Core.Models;
using Finnova.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinnovaWebApplication.Controllers
{
    public class BancosController : Controller
    {
        private readonly AppDbContext _context;

        public BancosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Bancos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Banco.ToListAsync());
        }

        // GET: Bancos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banco = await _context.Banco
                .FirstOrDefaultAsync(m => m.IdBanco == id);
            if (banco == null)
            {
                return NotFound();
            }

            return View(banco);
        }

        // GET: Bancos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bancos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBanco,Codigo,Nome,Ativo")] Banco banco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(banco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banco);
        }

        // GET: Bancos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banco = await _context.Banco.FindAsync(id);
            if (banco == null)
            {
                return NotFound();
            }
            return View(banco);
        }

        // POST: Bancos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBanco,Codigo,Nome,Ativo")] Banco banco)
        {
            if (id != banco.IdBanco)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(banco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BancoExists(banco.IdBanco))
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
            return View(banco);
        }

        // GET: Bancos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banco = await _context.Banco
                .FirstOrDefaultAsync(m => m.IdBanco == id);
            if (banco == null)
            {
                return NotFound();
            }

            return View(banco);
        }

        // POST: Bancos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banco = await _context.Banco.FindAsync(id);
            if (banco != null)
            {
                _context.Banco.Remove(banco);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BancoExists(int id)
        {
            return _context.Banco.Any(e => e.IdBanco == id);
        }
    }
}
