using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Notebook2.Data;
using Notebook2.ViewModel;

namespace Notebook2.Controllers
{
    public class notesController : Controller
    {
        private readonly Notebook2Context _context;

        public notesController(Notebook2Context context)
        {
            _context = context;
        }

        // GET: notes
        public async Task<IActionResult> Index()
        {
              return _context.notes != null ? 
                          View(await _context.notes.ToListAsync()) :
                          Problem("Entity set 'Notebook2Context.NoteBook'  is null.");
        }

        // GET: notes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.notes == null)
            {   
                return NotFound();
            }

            var notes = await _context.notes
                .FirstOrDefaultAsync(m => m.idnote == id);
            if (notes == null)
            {
                return NotFound();
            }

            return View(notes);
        }

        // GET: notes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: notes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idnote,iduser,note,date,description")] notes notes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notes);
        }

        // GET: notes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.notes == null)
            {
                return NotFound();
            }

            var notes = await _context.notes.FindAsync(id);
            if (notes == null)
            {
                return NotFound();
            }
            return View(notes);
        }

        // POST: notes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idnote,iduser,note,date,description")] notes notes)
        {
            if (id != notes.idnote)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!notesExists(notes.idnote))
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
            return View(notes);
        }

        // GET: notes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.notes == null)
            {
                return NotFound();
            }

            var notes = await _context.notes
                .FirstOrDefaultAsync(m => m.idnote == id);
            if (notes == null)
            {
                return NotFound();
            }

            return View(notes);
        }

        // POST: notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.notes == null)
            {
                return Problem("Entity set 'Notebook2Context.NoteBook'  is null.");
            }
            var notes = await _context.notes.FindAsync(id);
            if (notes != null)
            {
                _context.notes.Remove(notes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool notesExists(int id)
        {
          return (_context.notes?.Any(e => e.idnote == id)).GetValueOrDefault();
        }
    }
}
