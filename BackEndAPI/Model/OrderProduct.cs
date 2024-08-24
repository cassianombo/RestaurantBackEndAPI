using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Model
{
    [Table("OrderProduct")]
    public class OrderProduct
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [NotMapped]
        public decimal Subtotal
        {
            get
            {
                return Product.Price * Quantity; // Calcula o subtotal usando o preço do produto
            }
        }

    }
}
