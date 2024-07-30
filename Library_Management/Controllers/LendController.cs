using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library_Management.Data;
using Library_Management.Models;

namespace Library_Management.Controllers
{
    public class LendController : Controller
    {
        private readonly Library_ManagementContext _context;

        public LendController(Library_ManagementContext context)
        {
            _context = context;
        }

        // GET: Lend
        public async Task<IActionResult> Index(int? searchString)
        {
            var stubook = from b in _context.Lend
                        select b;

            if (searchString.HasValue)
            {
                    
                        // Search by ID
                   stubook = stubook.Where(s => s.Id == searchString);
                   
            }

            return View(await stubook.ToListAsync());
        }

        // GET: Lend/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lend = await _context.Lend
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lend == null)
            {
                return NotFound();
            }

            return View(lend);
        }

        // GET: Lend/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lend/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Bid,Sid,Issue_date,Return_date,Status")] Lend lend)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(lend);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
               
                     ModelState.AddModelError("", "Unable to save changes. Book already issued");
                    
                }
            }
            return View(lend);
            
        }

        // GET: Lend/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lend = await _context.Lend.FindAsync(id);
            if (lend == null)
            {
                return NotFound();
            }
            return View(lend);
        }

        // POST: Lend/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Bid,Sid,Issue_date,Return_date,Status")] Lend lend)
        {
            if (id != lend.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lend);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LendExists(lend.Id))
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
            return View(lend);
        }

        // GET: Lend/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lend = await _context.Lend
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lend == null)
            {
                return NotFound();
            }

            return View(lend);
        }

        // POST: Lend/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lend = await _context.Lend.FindAsync(id);
            if (lend != null)
            {
                _context.Lend.Remove(lend);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LendExists(int id)
        {
            return _context.Lend.Any(e => e.Id == id);
        }
    }
}
