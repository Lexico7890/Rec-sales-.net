using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecSalesWeb.Data;
using RecSalesWeb.Data.Entities;

namespace RecSalesWeb.Controllers
{
    public class NotifiesController : Controller
    {
        private readonly DataContext _context;

        public NotifiesController(DataContext context)
        {
            _context = context;
        }

        // GET: Notifies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Notifies.ToListAsync());
        }

        // GET: Notifies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notifyEntity = await _context.Notifies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notifyEntity == null)
            {
                return NotFound();
            }

            return View(notifyEntity);
        }

        // GET: Notifies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notifies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Description")] NotifyEntity notifyEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notifyEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notifyEntity);
        }

        // GET: Notifies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notifyEntity = await _context.Notifies.FindAsync(id);
            if (notifyEntity == null)
            {
                return NotFound();
            }
            return View(notifyEntity);
        }

        // POST: Notifies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Description")] NotifyEntity notifyEntity)
        {
            if (id != notifyEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notifyEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotifyEntityExists(notifyEntity.Id))
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
            return View(notifyEntity);
        }

        // GET: Notifies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notifyEntity = await _context.Notifies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notifyEntity == null)
            {
                return NotFound();
            }

            return View(notifyEntity);
        }

        // POST: Notifies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notifyEntity = await _context.Notifies.FindAsync(id);
            _context.Notifies.Remove(notifyEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotifyEntityExists(int id)
        {
            return _context.Notifies.Any(e => e.Id == id);
        }
    }
}
