using System.ComponentModel.DataAnnotations;
namespace NetCore6WebAdminLte2.Models
{
    public class OgrenciTable
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "boş geçilemez!")]
        public string? ad { get; set; }
        [Required(ErrorMessage = "boş geçilemez!")]
        public string? soyad { get; set; }
    }
}
