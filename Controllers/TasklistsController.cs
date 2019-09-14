using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TasklistProject1.Data;
using TasklistProject1.Models;

namespace TasklistProject.Controllers
{
    public class TasklistsController : Controller
    {
        private readonly TasklistContext _context;

        public TasklistsController(TasklistContext context)
        {
            _context = context;
        }

        // GET: Tasklists
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tasklists.ToListAsync());
        }

        // GET: Tasklists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasklist = await _context.Tasklists
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tasklist == null)
            {
                return NotFound();
            }

            return View(tasklist);
        }

        // GET: Tasklists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasklists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TaskTitulo,TaskDescricao,TaskDataCriacao,TaskStatus,TaskDataConclusao")] Tasklist tasklist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tasklist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tasklist);
        }

        // GET: Tasklists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasklist = await _context.Tasklists.FindAsync(id);
            if (tasklist == null)
            {
                return NotFound();
            }
            return View(tasklist);
        }

        // POST: Tasklists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TaskTitulo,TaskDescricao,TaskDataCriacao,TaskStatus,TaskDataConclusao")] Tasklist tasklist)
        {
            if (id != tasklist.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tasklist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TasklistExists(tasklist.ID))
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
            return View(tasklist);
        }

        // GET: Tasklists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasklist = await _context.Tasklists
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tasklist == null)
            {
                return NotFound();
            }

            return View(tasklist);
        }

        // POST: Tasklists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tasklist = await _context.Tasklists.FindAsync(id);
            _context.Tasklists.Remove(tasklist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TasklistExists(int id)
        {
            return _context.Tasklists.Any(e => e.ID == id);
        }
    }
}
