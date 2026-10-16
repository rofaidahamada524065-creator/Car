using System.ComponentModel.DataAnnotations;

namespace Car.DTOs.Customer
{
    public class historyandmoney
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(20)]
        public string Phone { get; set; }
        [Required, MaxLength(30)]
        public string DriverLicenseNumber { get; set; }
        public string Address { get; set; }
        [MaxLength(100)]
        public string? City { get; set; }
        [MaxLength(50)]
        public string? Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public int TotalVehicles { get; set; }
        public decimal MoneySpent { get; set; }




    }
}
