using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VGCatalogApp.Data;
using VGCatalogApp.Models;

namespace VGCatalogApp.Controllers
{
    public class VGSystemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VGSystemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VGSystems
        public async Task<IActionResult> Index()
        {
            return View(await _context.VGSystem.ToListAsync());
        }

        // GET: VGSystems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vGSystem = await _context.VGSystem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vGSystem == null)
            {
                return NotFound();
            }

            return View(vGSystem);
        }

        // GET: VGSystems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VGSystems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Consoles,Title")] VGSystem vGSystem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vGSystem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vGSystem);
        }

        // GET: VGSystems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vGSystem = await _context.VGSystem.FindAsync(id);
            if (vGSystem == null)
            {
                return NotFound();
            }
            return View(vGSystem);
        }

        // POST: VGSystems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Consoles,Title")] VGSystem vGSystem)
        {
            if (id != vGSystem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vGSystem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VGSystemExists(vGSystem.Id))
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
            return View(vGSystem);
        }

        // GET: VGSystems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vGSystem = await _context.VGSystem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vGSystem == null)
            {
                return NotFound();
            }

            return View(vGSystem);
        }

        // POST: VGSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vGSystem = await _context.VGSystem.FindAsync(id);
            _context.VGSystem.Remove(vGSystem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VGSystemExists(int id)
        {
            return _context.VGSystem.Any(e => e.Id == id);
        }
    }
}
