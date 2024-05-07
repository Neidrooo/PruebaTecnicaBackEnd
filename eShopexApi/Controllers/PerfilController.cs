using Microsoft.AspNetCore.Mvc;
using eShopexApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace eShopexApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly eShopexBDContext _context;

        public PerfilController(eShopexBDContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Perfil>>> GetPerfil()
        {
            return await _context.Perfil.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Perfil>> GetPerfil(int id)
        {
            var perfil = await _context.Perfil.FindAsync(id);

            if (perfil == null)
            {
                return NotFound();
            }

            return perfil;
        }
    }
}
