using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car.Model
{
    public class CustomerProfile
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(250)]
        public string Address { get; set; }
        [MaxLength(100)]
        public string ?City { get; set; }
        [MaxLength(50)]
        public string ?Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? customer { get; set; }
    }
}
