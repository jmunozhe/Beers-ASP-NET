using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testASP.Models;
using testASP.Models.ViewModels;

namespace testASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBeerController : ControllerBase
    {
        private readonly PubContext _context;

        public ApiBeerController(PubContext context) {
            _context = context;
        }

        public async Task<List<BeerBrandViewModel>> Get()
        
            => await _context.Beer1s.Include(b=>b.Brand)
            .Select(b=>new BeerBrandViewModel
            {
                Name = b.Name,
                Brand = b.Brand.Name
            })
            .ToListAsync();
        
    }
}
