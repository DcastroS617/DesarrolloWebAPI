using DesarrolloWebAPI.Data;
using DesarrolloWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DesarrolloWebAPI
{
    [ApiController]
    [Route("api/Alimento/Busqueda")]
    public class BusquedaAlimentoController : ControllerBase
    {
        private readonly SQLDbContext _context;
        public BusquedaAlimentoController(SQLDbContext context)
        {
            _context = context;
        }

        [HttpGet("{titulo_Alimento}")]
        public async Task<ActionResult<Alimento>> BuscarAlimento(string titulo_Alimento)
        {
            var alimento = from a in _context.Alimentos select a;
            if (alimento == null) return BadRequest();
            await alimento.ToListAsync();
            foreach(var a in alimento)
            {
                return Ok(_context.Alimentos.FromSqlRaw("SELECT * FROM[dbo].[Alimentos] where titulo_Alimento like '" + titulo_Alimento+"%'"));
            }
            return NotFound();
        }
    }
}
