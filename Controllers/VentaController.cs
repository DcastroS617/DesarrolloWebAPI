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
    [Route("api/Venta")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly SQLDbContext _context;
        public VentaController(SQLDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVenta()
        {
            return await _context.Ventas.Select(info => info).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Venta>> PostVenta(Venta venta)
        {
            //animal.Precio_Animal = animal.Precio_Animal + (animal.Precio_Animal * .13);
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVenta), new { id = venta.Id}, venta);
        }
    }
}
