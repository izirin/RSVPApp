#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RSVPApp.Models;

namespace RSVPApp.Controllers
{
    public class GuestRespondsController : Controller
    {
        private readonly RSVPContext _context;

        public GuestRespondsController(RSVPContext context)
        {
            _context = context;
        }

        // GET: GuestResponds
        public async Task<IActionResult> Index()
        {
            return View(await _context.GuestRespond.ToListAsync());
        }

        // GET: GuestResponds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestRespond = await _context.GuestRespond
                .FirstOrDefaultAsync(m => m.GuestRespondId == id);
            if (guestRespond == null)
            {
                return NotFound();
            }

            return View(guestRespond);
        }

        // GET: GuestResponds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GuestResponds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuestRespondId,Name,Email,Phone,Attend")] GuestRespond guestRespond)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guestRespond);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guestRespond);
        }

        // GET: GuestResponds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestRespond = await _context.GuestRespond.FindAsync(id);
            if (guestRespond == null)
            {
                return NotFound();
            }
            return View(guestRespond);
        }

        // POST: GuestResponds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GuestRespondId,Name,Email,Phone,Attend")] GuestRespond guestRespond)
        {
            if (id != guestRespond.GuestRespondId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guestRespond);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestRespondExists(guestRespond.GuestRespondId))
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
            return View(guestRespond);
        }

        // GET: GuestResponds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestRespond = await _context.GuestRespond
                .FirstOrDefaultAsync(m => m.GuestRespondId == id);
            if (guestRespond == null)
            {
                return NotFound();
            }

            return View(guestRespond);
        }

        // POST: GuestResponds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guestRespond = await _context.GuestRespond.FindAsync(id);
            _context.GuestRespond.Remove(guestRespond);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestRespondExists(int id)
        {
            return _context.GuestRespond.Any(e => e.GuestRespondId == id);
        }
    }
}
