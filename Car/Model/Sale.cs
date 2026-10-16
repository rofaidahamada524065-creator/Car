using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car.Model
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime SaleDate { get; set; }
        [Required   ,Range(1,int.MaxValue)]
        public decimal SalePrice { get; set; }
        [Required]
        [MaxLength(30)]
        public string PaymentMethod { get; set; }
        [MaxLength(300)]
        public string ?Note { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer ?customer { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee ?employee { get; set; }

        public int VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public Vehicle vehicle { get; set; }
    }
}
