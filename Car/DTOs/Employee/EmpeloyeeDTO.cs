using System.ComponentModel.DataAnnotations;

namespace Car.DTOs.Employee
{
    public class EmpeloyeeDTO
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string FullName { get; set; }
        [Required, MaxLength(100)]
        public string Position { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(20)]
        public string? Phone { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
    }
}
