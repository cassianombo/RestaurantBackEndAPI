using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Model
{
    [Table("Payment")]
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [Required]
        public DateTime PaymentDateTime { get; set; }

        [Required]
        public decimal Amount { get; set; }

    }
}
