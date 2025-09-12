using Kalendarz.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kalendarz.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly kalendarzDbContext _context;

        public EventsController(kalendarzDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]//zaytania do bazy danych wykonujemy poprzez httpget
        public async Task<IActionResult> GetById(int id)
        {
            var wynik = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (wynik == null)
            {
                return NotFound();
            }
            return Ok(wynik);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Event newEvent)
        {
            if (newEvent == null || newEvent.Start == null || newEvent.End == null || string.IsNullOrEmpty(newEvent.Title)) {
                return BadRequest();
            }

            newEvent.EventType = await _context.eventTypes.FirstOrDefaultAsync(e => e.Id == newEvent.EventTypeId);

            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newEvent.Id }, newEvent); //nazwa metody do wywolania, obiekt z argumentami do metody, obiekt z ktorego pobieramy argumenty
        }
        [HttpGet("{dateStart}/{dateEnd}")]
        public async Task<IActionResult> GetByDateRange(DateTime dateStart, DateTime dateEnd)
        {
            var wynik = await (_context.Events.Where(e => e.Start <= dateStart && e.End >= dateEnd).ToListAsync());
            if (wynik == null) return NotFound();
            wynik.ForEach(async e => 
                e.EventType = await _context.eventTypes
                    .FirstOrDefaultAsync(et => et.Id == e.EventTypeId)
            );
            return Ok(wynik);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            _context.Events.Remove(await _context.Events.FirstOrDefaultAsync(e=> e.Id == id));
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var wynik = await _context.Events.ToListAsync();

            return Ok(wynik);
        }
    }
}
