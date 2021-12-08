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
    [Route("api/Alimento")]
    [ApiController]
    public class AlimentoController :ControllerBase
    {
        private readonly SQLDbContext _context;
        public AlimentoController(SQLDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alimento>>> GetAlimento()
        {
            return await _context.Alimentos.Select(Info => Info).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Alimento>> PostAlimento(Alimento alimento)
        {
            alimento.Precio_Alimento = alimento.Precio_Alimento + (alimento.Precio_Alimento * .13);
            _context.Alimentos.Add(alimento);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAlimento), new { id = alimento.Id }, alimento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlimento(int id, Alimento alimento)
        {
            if (id != alimento.Id) return BadRequest();
            _context.Entry(alimento).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!BuscarAlimento(id)) { return NotFound(); } else { throw; }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlimento(int id)
        {
            var info = await _context.Alimentos.FindAsync(id);
            if(info == null) return BadRequest();
            _context.Alimentos.Remove(info);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("{ProveedorId}")]
        public async Task<ActionResult<Alimento>> BuscarPorProveedor(int ProveedorId)
        {
            var info = from p in _context.Alimentos select p;
            info.Where(info => ProveedorId == info.ProveedorId);
            await info.ToListAsync();
            foreach(var i in info)
            {
                if(ProveedorId == i.ProveedorId)
                {
                    return Ok(_context.Alimentos.FromSqlRaw("Select * from [dbo].[Alimentos]").Where(p => p.ProveedorId == ProveedorId));
                }               
            }

            return NotFound();

        }
        private bool BuscarAlimento(int id) { return _context.Alimentos.Any(info => id == info.Id); }
    }
}
