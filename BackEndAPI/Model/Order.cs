using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Model
{
    [Table("Order")]
    //public class Order
    //{
    //    [Key]
    //    public int Id { get; set; }

    //    [ForeignKey("Table")]
    //    public int? TableId { get; set; }
    //    public Table? Table { get; set; }

    //    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    //}

    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TableId { get; set; }

        [ForeignKey("TableId")]
        public RestaurantTable Table { get; set; }

        [Required]
        public DateTime OrderDateTime { get; set; } = DateTime.Now;

        public List<OrderProduct> Products { get; set; } = new List<OrderProduct>();

        [Required]
        public decimal TotalAmount
        {
            get
            {
                return Products.Sum(item => item.Subtotal); // Calcula o valor total do pedido
            }
        }

    }
}
