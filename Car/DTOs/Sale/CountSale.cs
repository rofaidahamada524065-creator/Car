using Car.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car.DTOs.Sale
{
    public class CountSale
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
      public   int countSale { get; set; }
    }
}
