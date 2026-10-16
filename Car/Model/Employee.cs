using System.ComponentModel.DataAnnotations;

namespace Car.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string FullName { get; set; }
        [Required,MaxLength(100)]
        public string Position { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [ MaxLength(20)]
        public string? Phone { get; set; }
        [Required]
        public DateTime HireDate { get; set; }

        public ICollection<Sale> sales { get; set; } = new List<Sale>();
    }
}
