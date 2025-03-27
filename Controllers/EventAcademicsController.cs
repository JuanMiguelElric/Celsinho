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
    public class EventAcademicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventAcademicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventAcademics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Eventacademics.ToListAsync());
        }

        // GET: EventAcademics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventAcademic = await _context.Eventacademics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventAcademic == null)
            {
                return NotFound();
            }

            return View(eventAcademic);
        }

        // GET: EventAcademics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventAcademics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] EventAcademic eventAcademic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventAcademic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventAcademic);
        }

        // GET: EventAcademics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventAcademic = await _context.Eventacademics.FindAsync(id);
            if (eventAcademic == null)
            {
                return NotFound();
            }
            return View(eventAcademic);
        }

        // POST: EventAcademics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] EventAcademic eventAcademic)
        {
            if (id != eventAcademic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventAcademic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventAcademicExists(eventAcademic.Id))
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
            return View(eventAcademic);
        }

        // GET: EventAcademics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventAcademic = await _context.Eventacademics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventAcademic == null)
            {
                return NotFound();
            }

            return View(eventAcademic);
        }

        // POST: EventAcademics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventAcademic = await _context.Eventacademics.FindAsync(id);
            if (eventAcademic != null)
            {
                _context.Eventacademics.Remove(eventAcademic);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventAcademicExists(int id)
        {
            return _context.Eventacademics.Any(e => e.Id == id);
        }
    }
}
