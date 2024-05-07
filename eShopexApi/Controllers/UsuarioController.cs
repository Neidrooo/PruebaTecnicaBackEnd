using Microsoft.AspNetCore.Mvc;
using eShopexApi.Models;
using Microsoft.EntityFrameworkCore;

namespace eShopexApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly eShopexBDContext _context;

        public UsuarioController(eShopexBDContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario([FromBody] Usuario usuario)
        {
            if (usuario.Fecha_nacimiento > DateTime.UtcNow)
            {
                return BadRequest("La fecha de nacimiento no puede ser una fecha futura.");
            }

            if (usuario.Password.Contains(usuario.Nombre_usuario) || usuario.Password.Length < 10)
            {
                return BadRequest("La contraseña no debe contener el nombre de usuario y debe tener más de 10 caracteres de longitud.");
            }
            usuario.Password = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
            usuario.Activo = 1;
            usuario.Fecha_creacion = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Pacific SA Standard Time"));

            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id_usuario }, usuario);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuario.ToListAsync();
        }
    }
}
