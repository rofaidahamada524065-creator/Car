using System.ComponentModel.DataAnnotations;

namespace Car.DTOs.Customer
{
    public class CustomerDTO
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

    }
}
