using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
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
    public class MatriculasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatriculasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Matriculas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Matriculas.Include(m => m.EventAcademic);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Matriculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
       

            var matricula = await _context.Matriculas
                .Include(m => m.EventAcademic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // GET: Matriculas/Create
        public IActionResult Create()
        {
            // Obtendo o UserId do usuário autenticado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Criando a nova matrícula e atribuindo o UserId
            var matricula = new Matricula
            {
                UserId = userId // Atribuindo o UserId ao modelo
            };

            // Criando a lista de eventos acadêmicos para o dropdown
            var eventAcademics = _context.Eventacademics
                .Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(), // Usando o Id como valor
                    Text = e.Nome // Usando o Nome como texto exibido no dropdown
                }).ToList();

            // Passando a lista de eventos acadêmicos para a View através do ViewData
            ViewData["EventAcademics_Id"] = eventAcademics;

            return View(matricula);
        }




        // POST: Matriculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,EventAcademics_Id")] Matricula matricula)
        {
            // Obtendo o UserId do usuário autenticado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Atribuindo o UserId à matrícula
            matricula.UserId = userId;
            Debug.WriteLine("UserId: " + userId);


            // Verificando se o modelo é válido
            if (ModelState.IsValid)
            {
                // Adicionando a matrícula ao contexto
                _context.Add(matricula);

                // Salvando as alterações no banco de dados
                await _context.SaveChangesAsync();

                // Redirecionando para a ação Index após salvar
                return RedirectToAction(nameof(Index));
            }

            // Caso o modelo não seja válido, repopulando o dropdown de eventos acadêmicos
            ViewData["EventAcademics_Id"] = new SelectList(_context.Eventacademics, "Id", "Nome", matricula.EventAcademics_Id);

            // Retornando a view com o modelo para corrigir os erros
            return View(matricula);
        }




        // GET: Matriculas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula == null)
            {
                return NotFound();
            }
            ViewData["EventAcademics_Id"] = new SelectList(_context.Eventacademics, "Id", "Nome", matricula.EventAcademics_Id);
            return View(matricula);
        }

        // POST: Matriculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,EventAcademics_Id")] Matricula matricula)
        {
            if (id != matricula.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matricula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatriculaExists(matricula.Id))
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
            ViewData["EventAcademics_Id"] = new SelectList(_context.Eventacademics, "Id", "Nome", matricula.EventAcademics_Id);
            return View(matricula);
        }

        // GET: Matriculas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas
                .Include(m => m.EventAcademic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula != null)
            {
                _context.Matriculas.Remove(matricula);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatriculaExists(int id)
        {
            return _context.Matriculas.Any(e => e.Id == id);
        }
    }
}
