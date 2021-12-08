using DesarrolloWebAPI.Data;
using DesarrolloWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloWebAPI.Controllers
{
    [ApiController]
    [Route("api/Articulo/Busqueda")]
    public class BusquedaArticuloController : ControllerBase
    {
        private readonly SQLDbContext _context;
        public BusquedaArticuloController(SQLDbContext context)
        {
            _context = context;
        }
        [HttpGet("{nombre_Articulo}")]
        public async Task<ActionResult<Articulo>> BuscarArticulo(string nombre_Articulo)
        {
            var articulo = from a in _context.Articulos select a;
            if (articulo == null) return BadRequest();
            await articulo.ToListAsync();
            foreach(var a in articulo)
            {
                return Ok(_context.Articulos.FromSqlRaw("SELECT * FROM [dbo].[Articulos] where nombre_articulo like '"+nombre_Articulo+"%'"));
            }
            return NotFound();
        }
    }
}
