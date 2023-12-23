﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PSP_PoS.Components.Account;
using PSP_PoS.Components.Customer;
using PSP_PoS.Components.Discount;
using PSP_PoS.Components.Tax;
using PSP_PoS.Enums;

namespace PSP_PoS.Components.Service
{
    public class ServiceModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("CategoryModel")]
        public Guid CategoryId { get; set; }

        [ForeignKey("DiscountModel")]
        public Guid DiscountId { get; set; }

    }
}
