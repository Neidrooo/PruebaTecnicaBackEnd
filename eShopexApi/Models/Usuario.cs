using System.ComponentModel.DataAnnotations;

namespace eShopexApi.Models
{
    public class Usuario
    {
        [Key]
        public int Id_usuario { get; set; }
        public string Nombre_usuario { get; set; }
        public string Password { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public DateTime? Fecha_creacion { get; set; }
        public int Id_perfil { get; set; }
        public int? Activo { get; set; }
    }
}
