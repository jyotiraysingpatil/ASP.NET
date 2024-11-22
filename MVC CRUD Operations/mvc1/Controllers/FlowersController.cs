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
    }
}
