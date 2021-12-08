using DesarrolloWebAPI.Data;
using DesarrolloWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesarrolloWebAPI
{
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController :ControllerBase
    {
        private readonly SQLDbContext _context;

        public UsuarioController(SQLDbContext context)
        {
        _context= context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuarios.Select(info => info).ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            var login = new Login() { Telefono = usuario.Telefono, Contrasena = usuario.Contrasena };
            _context.Usuarios.Add(usuario);
            _context.Logins.Add(login);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<Usuario>> Login(Login login)
        {
            var numero = await _context.Logins.AnyAsync(Info => Info.Telefono == login.Telefono);
            var contrasena = await _context.Logins.AnyAsync(info => info.Contrasena == login.Contrasena);
            if (numero && contrasena) return NoContent();
            return NotFound();
        }

        [Route("GetLogin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Login>>> GetLogins()
        {
            return await _context.Logins.Select(info => info).ToListAsync();
        }

    }
}
