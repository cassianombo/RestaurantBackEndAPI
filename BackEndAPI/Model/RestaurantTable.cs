using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Model
{
    [Table("RestaurantTable")]
    public class RestaurantTable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public int Capacity { get; set; }

        public bool IsOccupied { get; set; }
    }
}
