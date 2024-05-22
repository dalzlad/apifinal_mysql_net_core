using APIOfertas.Data;
using APIOfertas.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIOfertas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoOfertaController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoOferta>>> GetTipoOfertas()
        {
            return await _context.TipoOferta.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoOferta>> GetTipoOferta(int id)
        {
            var tipooferta = await _context.TipoOferta.FindAsync(id);

            if (tipooferta == null)
            {
                return NotFound();
            }

            return tipooferta;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTipoOferta([FromBody] TipoOferta tipooferta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.TipoOferta.Add(tipooferta);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTipoOferta", new { id = tipooferta.Id }, tipooferta);
            return CreatedAtAction(nameof(GetTipoOferta), new { id = tipooferta.Id }, tipooferta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoOferta(int id, TipoOferta tipooferta)
        {
            if (id != tipooferta.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipooferta).State = EntityState.Modified;

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
        public async Task<IActionResult> DeleteTipoOferta(int id)
        {
            var tipooferta = await _context.TipoOferta.FindAsync(id);
            if (tipooferta == null)
            {
                return NotFound();
            }

            _context.TipoOferta.Remove(tipooferta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfertaExists(int id)
        {
            return _context.TipoOferta.Any(e => e.Id == id);
        }
    }
}
