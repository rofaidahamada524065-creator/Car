using System.ComponentModel.DataAnnotations;

namespace Car.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string  Name { get; set; }
        [MaxLength(200)]
        public string ? Discreption { get; set; }


        public ICollection<Vehicle> vehicles { get; set; } = new List<Vehicle>();
    }
}
