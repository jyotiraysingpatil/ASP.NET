using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc1.Data;
using mvc1.Models;
using System.Threading.Tasks;

namespace mvc1.Controllers
{
    public class FlowersController : Controller
    {
        private readonly FlowerContext _context;

        public FlowersController(FlowerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Flowers.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Flowers flower)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flower);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flower);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flower = await _context.Flowers
                .FirstOrDefaultAsync(m => m.id == id);
            if (flower == null)
            {
                return NotFound();
            }

            return View(flower);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var flower = await _context.Flowers.FindAsync(id);
            if (flower == null)
            {
                return NotFound();
            }
            return View(flower);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Flowers flower)
        {
            if (id != flower.id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flower);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlowerExists(flower.id))
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
            return View(flower);
        }

        private bool FlowerExists(int id)
        {
            return _context.Flowers.Any(e => e.id == id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var flower = await _context.Flowers.FirstOrDefaultAsync(m => m.id == id);
            if (flower == null)
            {
                return NotFound();
            }
            return View(flower);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DelteConfirmed(int id)
        {
            var flower = await _context.Flowers.FindAsync(id);
            _context.Flowers.Remove(flower);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

