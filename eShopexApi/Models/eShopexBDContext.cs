using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace eShopexApi.Models
{
    public class eShopexBDContext : DbContext
    {
        public eShopexBDContext(DbContextOptions<eShopexBDContext> options) : base(options)
        {
        }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}
