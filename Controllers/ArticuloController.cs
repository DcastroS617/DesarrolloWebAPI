using DesarrolloWebAPI.Data;
using DesarrolloWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesarrolloWebAPI.Controllers
{
    [Route("api/Articulo")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        public readonly SQLDbContext _context;
        public ArticuloController(SQLDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulo>>> GetArticulo()
        {
            return await _context.Articulos.Select(Info => Info).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Articulo>> PostArticulo(Articulo articulo)
        {
            articulo.Precio_Articulo = articulo.Precio_Articulo + (articulo.Precio_Articulo * .13);
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetArticulo), new { id = articulo.Id }, articulo);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulo(int id, Articulo articulo)
        {
            if (id != articulo.Id) return BadRequest();
            _context.Entry(articulo).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuscarArticulo(id)) { return NotFound(); } else { throw; }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulo(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null) return BadRequest();
            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();
            return NoContent();   
        }

        [HttpGet("{ProveedorId}")]
        public async Task<ActionResult> GetProveedorArticulo(int ProveedorId)
        {
            var info = from p in _context.Articulos select p;
            info.Where(p => p.ProveedorId == ProveedorId);
            await info.ToListAsync();
            foreach(var i in info)
            {
                if(i.ProveedorId == ProveedorId)
                {
                    return Ok(_context.Articulos.FromSqlRaw("Select * from [dbo].[Articulos]").Where(p => p.ProveedorId == ProveedorId));
                } 
            }
            return NotFound();
        }
        private bool BuscarArticulo(int id) { return _context.Articulos.Any(info => id == info.Id); }
    }
}
