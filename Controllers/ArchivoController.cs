using DesarrolloWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesarrolloWebAPI.Controllers
{
    [ApiController]
    [Route("api/Archivo")]
    public class ArchivoController : ControllerBase
    {
        private readonly SQLDbContext _context;
        public ArchivoController(SQLDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Archivo>>> GetArchivo()
        {
            return await _context.Archivos.Select(x => x).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Archivo>> GetArchivo(int id)
        {
            var archivo = await _context.Archivos.FindAsync(id);
            if (archivo == null) return NotFound();
            return archivo;
        }

        [HttpPost]
        public async Task<ActionResult> PostArchivo(Archivo archivo)
        {
            _context.Archivos.Add(archivo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetArchivo), new { id = archivo.id }, archivo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchivo(int id, Archivo archivo)
        {
            if (id != archivo.id) return BadRequest();
            _context.Entry(archivo).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuscarArchivo(id)) { return NotFound(); } else { throw; }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArchivo(int id)
        {
            var archivo = await _context.Archivos.FindAsync(id);
            if(archivo == null) { return BadRequest(); }
            _context.Archivos.Remove(archivo);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool BuscarArchivo(int id) { return _context.Archivos.Any(info => id == info.id); }
    }
}
