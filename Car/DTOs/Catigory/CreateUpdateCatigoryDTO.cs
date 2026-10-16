using System.ComponentModel.DataAnnotations;

namespace Car.DTOs.Catigory
{
    public class CreateUpdateCatigoryDTO
    {
    
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Discreption { get; set; }
    }
}
