using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testASP.Models;
using testASP.Models.ViewModels;

namespace testASP.Controllers
{
    public class BeerController : Controller
    {
        private readonly PubContext _context;
        public BeerController(PubContext context) {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var beers = _context.Beer1s.Include(b => b.Brand);
            return View(await beers.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["Brands"] = new SelectList(_context.Brand1s, "BrandId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BeerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var beer = new Beer1()
                {
                    Name = model.Name,
                    BrandId = model.BrandId
                };
                _context.Add(beer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Brands"] = new SelectList(_context.Brand1s, "BrandId", "Name",model.BrandId);
            return View(model);
        }
    }
}
