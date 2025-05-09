using Booking_Management_system.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking_Management_system.Controllers
{
    public class VenueController : Controller
    {
        private readonly ApplicationDBContext _context;

        public VenueController(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var venues = await _context.Venue.ToListAsync();
            return View(venues);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Venue venue)
        {
            if (ModelState.IsValid)
            {
                _context.Venue.Add(venue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venue);
        }

        public IActionResult Edit(int id)
        {
            var venue = _context.Venue.Find(id);
            if (venue == null)
            {
                return NotFound();
            }
            return View(venue);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Venue venue)
        {
            if (id != venue.VENUE_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Venue.Any(e => e.VENUE_ID == venue.VENUE_ID))
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
            return View(venue);
        }

        public IActionResult Delete(int id)
        {
            var venue = _context.Venue.Find(id);
            if (venue == null)
            {
                return NotFound();
            }
            return View(venue);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venue = await _context.Venue.FindAsync(id);
            if (venue != null)
            {
                _context.Venue.Remove(venue);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var venue = _context.Venue.Find(id);
            if (venue == null)
            {
                return NotFound();
            }
            return View(venue);
        }
    }
}
