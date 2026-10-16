using System.ComponentModel.DataAnnotations;

namespace Car.DTOs.Vehicles
{
    public class Vehicle_DTO
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Make { get; set; }
        [Required, MaxLength(100)]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [MaxLength(50)]
        public string? Color { get; set; }
        [Required]
        [Range(0.01, int.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Mileage { get; set; }
        [Required, MaxLength(17)]
        public string VIN { get; set; }
        [MaxLength(30)]
        public string? FuelType { get; set; }
        [MaxLength(30)]
        public string? Transmission { get; set; }
        [Required]
        public string Status { get; set; }
        public int CatigoryId { get; set; }
    }
}
