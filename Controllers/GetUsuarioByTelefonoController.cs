using DesarrolloWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DesarrolloWebAPI.Controllers
{  
    [Route("api/Usuario/Get")]
    [ApiController]
    public class GetUsuarioByTelefonoController : ControllerBase
    {
        private readonly SQLDbContext _context;
        public GetUsuarioByTelefonoController(SQLDbContext context)
        {
            _context = context;
        }
        [HttpGet("{Telefono}")]
        public async Task<ActionResult> GetUsuario(string Telefono)
        {
            var usuario = from u in _context.Usuarios select u;
            if (!String.IsNullOrEmpty(Telefono))
            {
                usuario.Where(u => u.Telefono.Contains(Telefono));
            }
            await usuario.ToListAsync();
            foreach(var user in usuario)
            {
                if(user.Telefono == Telefono)
                {
                    var send = _context.Usuarios.FindAsync(user.Id);
                    return Ok(send);
                }
            }
            return NotFound();
        }
    }
}
