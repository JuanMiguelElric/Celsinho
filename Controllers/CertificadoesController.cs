using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sbelt.Data;
using sbelt.Models;

namespace sbelt.Controllers
{
    [Authorize]
    public class CertificadoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CertificadoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Certificadoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Certificado.Include(c => c.Matricula);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Certificadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificado = await _context.Certificado
                .Include(c => c.Matricula)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certificado == null)
            {
                return NotFound();
            }

            return View(certificado);
        }

        // GET: Certificadoes/Create
        public IActionResult Create()
        {

            ViewData["MatriculaId"] = new SelectList(_context.Matriculas, "Id", "UserId");
            return View();
        }

        // POST: Certificadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Key,Conclusao,MatriculaId")] Certificado certificado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(certificado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MatriculaId"] = new SelectList(_context.Matriculas, "Id", "UserId", certificado.MatriculaId);
            return View(certificado);
        }

        // GET: Certificadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificado = await _context.Certificado.FindAsync(id);
            if (certificado == null)
            {
                return NotFound();
            }
            ViewData["MatriculaId"] = new SelectList(_context.Matriculas, "Id", "UserId", certificado.MatriculaId);
            return View(certificado);
        }

        // POST: Certificadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Key,Conclusao,MatriculaId")] Certificado certificado)
        {
            if (id != certificado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certificado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificadoExists(certificado.Id))
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
            ViewData["MatriculaId"] = new SelectList(_context.Matriculas, "Id", "UserId", certificado.MatriculaId);
            return View(certificado);
        }

        // GET: Certificadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificado = await _context.Certificado
                .Include(c => c.Matricula)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certificado == null)
            {
                return NotFound();
            }

            return View(certificado);
        }

        // POST: Certificadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var certificado = await _context.Certificado.FindAsync(id);
            if (certificado != null)
            {
                _context.Certificado.Remove(certificado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CertificadoExists(int id)
        {
            return _context.Certificado.Any(e => e.Id == id);
        }
    }
}
