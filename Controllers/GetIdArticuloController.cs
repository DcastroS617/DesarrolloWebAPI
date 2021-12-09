using DesarrolloWebAPI.Data;
using DesarrolloWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DesarrolloWebAPI.Controllers
{
    [ApiController]
    [Route("api/Articulo/Get")]
    public class GetIdArticuloController : ControllerBase
    {
        private readonly SQLDbContext _context;
        public GetIdArticuloController(SQLDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Articulo>> GetArticulo(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null) return NotFound();
            return articulo;
        }
    }
}
