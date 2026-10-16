using System.ComponentModel.DataAnnotations;

namespace Car.Model
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(150)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required ,MaxLength(20)]
        public string Phone { get; set; }
        [Required ,MaxLength(30)]
        public string DriverLicenseNumber { get; set; }

        public CustomerProfile ?customerProfile { get; set; }
        public ICollection<Sale> sales { get; set; } = new List<Sale>();
    }
}
