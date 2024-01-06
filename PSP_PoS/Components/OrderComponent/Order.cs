using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PSP_PoS.Enums;
using PSP_PoS.Components.CustomerComponent;
using PSP_PoS.Components.EmployeeComponent;
using PSP_PoS.Components.TaxComponent;
using System.Text.Json.Serialization;
using PSP_PoS.Components.ItemOrderComponent;
using Microsoft.EntityFrameworkCore;
using PSP_PoS.Components.OrderService;

namespace PSP_PoS.Components.OrderComponent
{

    public class Order
    {
        [Key]
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        public Status OrderStatus { get; set; }

        public decimal? Tip { get; set; }

        public PaymentType PaymentType { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public Guid? TaxId {  get; set; }

        [ForeignKey("TaxId")]
        public Tax? Tax { get; set; }

        //Navigations
        [JsonIgnore]
        public List<OrderItems> OrderItems { get; set; }

        [JsonIgnore]
        public List<OrderServices> OrderServices {  get; set; }

        public Order()
        {

        }

        public Order(OrderCreateDto orderCreateDto)
        {
            EmployeeId = orderCreateDto.EmployeeId;
            CustomerId = orderCreateDto.CustomerId;
            DateCreated = DateTime.Now;
            OrderStatus = Status.InProgress;
            PaymentType = PaymentType.NotPaid;
        }
    }
}
