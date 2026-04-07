using Microsoft.AspNetCore.Mvc;
using InventarioAPI.Data;
using InventarioAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization; // 👈 NUEVO

namespace InventarioAPI.Controllers
{
    [Authorize] // 🔒 PROTEGE TODO
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Productos.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return Ok(producto);
        }
    }
}
