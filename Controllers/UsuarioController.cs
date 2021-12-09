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

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();
            return usuario;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id) return BadRequest();
            _context.Entry(usuario).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuscarUsuario(id)) { return NotFound(); } else { throw; }
            }
            return NoContent();
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
        private bool BuscarUsuario(int id) { return _context.Usuarios.Any(info => info.Id == id); }
    }
}
