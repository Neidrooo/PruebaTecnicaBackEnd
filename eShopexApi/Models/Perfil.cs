
using System.ComponentModel.DataAnnotations;

namespace eShopexApi.Models
{
    public class Perfil
    {
        [Key]
        public int Id_Perfil { get; set; }
        public string Nombre_perfil { get; set; }
    }
}
