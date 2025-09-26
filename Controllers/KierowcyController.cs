using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kalendarz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KierowcyController : ControllerBase
    {
        private readonly kalendarzDbContext _context;

        public KierowcyController(kalendarzDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var wynik = await _context.Kierowcy.ToListAsync();

            return Ok(wynik);
        }
    }
}
