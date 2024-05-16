using APIOfertas.Data;
using Microsoft.AspNetCore.Mvc;

namespace APIOfertas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Oferta>>> GetOfertas()
        {
            return await _context.Oferta.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Oferta>> GetOferta(int id)
        {
            var oferta = await _context.Oferta.FindAsync(id);

            if (oferta == null)
            {
                return NotFound();
            }

            return oferta;
        }

        [HttpPost]
        public async Task<ActionResult<Oferta>> PostCSharpCornerArticle(Oferta oferta)
        {
            _context.Oferta.Add(oferta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOferta", new { id = oferta.OfertaId }, oferta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOferta(int id, Oferta oferta)
        {
            if (id != oferta.OfertaId)
            {
                return BadRequest();
            }

            _context.Entry(oferta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfertaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOferta(int id)
        {
            var oferta = await _context.Oferta.FindAsync(id);
            if (oferta == null)
            {
                return NotFound();
            }

            _context.Oferta.Remove(oferta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfertaExists(int id)
        {
            return _context.Oferta.Any(e => e.OfertaId == id);
        }
    }
}
