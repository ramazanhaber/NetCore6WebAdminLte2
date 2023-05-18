using System.ComponentModel.DataAnnotations;

namespace NetCore6WebAdminLte2.Models
{
    public class Users
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "boş geçilemez!")]
        public string? username { get; set; }
        [Required(ErrorMessage = "boş geçilemez!")]
        public string? password { get; set; }
        public string? role { get; set; }
    }
}
