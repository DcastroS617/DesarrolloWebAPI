using DesarrolloWebAPI.Data;
using DesarrolloWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DesarrolloWebAPI.Controllers
{
    [ApiController]
    [Route("api/Alimento/Get")]
    public class GetIdAlimentoController : ControllerBase
    {
        private readonly SQLDbContext _context;       
        public GetIdAlimentoController(SQLDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Alimento>> GetAlimento(int id)
        {
            var alimento = await _context.Alimentos.FindAsync(id);
            if (alimento == null) return NotFound();
            return alimento;
        }
    }
}
