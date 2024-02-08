using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using TicketProject.Data;
using TicketProject.Models;

namespace TicketProject.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TicketController(ApplicationDbContext context)
        {
            _context = context;
        }
        //GET:
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var tickets = await _context.TicketEntries.Include(t => t.TicketSystemCategoryType).ToListAsync();
            return View(tickets);
        }

        //Get: /Create
        public IActionResult Create()
        {
            return View();

        }
        //Post /Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketEntryID,TicketSystemCategoryTypeID,Title,Description,CreatedDate")] TicketEntry ticketEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticketEntry);
        }
        //Get: /Edit
        public async Task<IActionResult> Edit(int id)
        {
            var ticketDetails = await _context.TicketEntries.Include(t => t.TicketSystemCategoryType).FirstOrDefaultAsync(m => m.TicketEntryID == id);
            return View(ticketDetails);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketEntryID,TicketSystemCategoryTypeID,Title,Description,CreatedDate")] TicketEntry ticketEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Attach(ticketEntry).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticketEntry);
        }
        // GET: /Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketEntry = await _context.TicketEntries
                .Include(t => t.TicketSystemCategoryType)
                .FirstOrDefaultAsync(m => m.TicketEntryID == id);

            if (ticketEntry == null)
            {
                return NotFound();
            }

            return View(ticketEntry);
        }

        // POST: /Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticketEntry = await _context.TicketEntries.FindAsync(id);
            if (ticketEntry == null)
            {
                return NotFound();
            }

            _context.TicketEntries.Remove(ticketEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
