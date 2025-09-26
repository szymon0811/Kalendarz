using Kalendarz.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kalendarz.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ZestawieniaController : ControllerBase
    {
        private readonly kalendarzDbContext _context;

        public ZestawieniaController (kalendarzDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Zestawienie zestawienie)
        {
            if (zestawienie == null) {
                return BadRequest();
            }

            zestawienie.Tor = await _context.Tory.FirstOrDefaultAsync(e => e.Id == zestawienie.IdToru);
            zestawienie.Kierowca = await _context.Kierowcy.FirstOrDefaultAsync(e => e.Id == zestawienie.IdKierowcy);

            await _context.Zestawienia.AddAsync(zestawienie);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetById),new {id = zestawienie.Id}, zestawienie);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var wynik = await _context.Zestawienia.FirstOrDefaultAsync(e=>e.Id == id);
            if(wynik == null)
            {
                return NotFound();
            }
            return Ok(wynik);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var wynik = await _context.Zestawienia.Include(e=>e.Kierowca).Include(e=>e.Tor).ToListAsync();

            return Ok(wynik);
        }
        [HttpGet("{torId}")]
        public async Task<IActionResult> ZestawieniaByTor(int torId)
        {
            var wynik = _context.Zestawienia.Where(z => z.IdToru == torId)
                .Include(e=>e.Kierowca).Include(e=>e.Tor).OrderBy(e=>e.Czas);
           
            return Ok(wynik);
        }
        [HttpGet("{kierowcaId}")]
        public async Task<IActionResult> ZestawieniaByKierowca(int kierowcaId)
        {
            var wynik = _context.Zestawienia.Where(z => z.IdKierowcy == kierowcaId)
                .Include(e => e.Kierowca).Include(e => e.Tor);

            return Ok(wynik);
        }
    }
}
