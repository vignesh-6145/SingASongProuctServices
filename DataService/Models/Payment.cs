using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public PaymentMethod PaymentMethod { get; set; } = null!;


        public string PurchaseType { get; set; } = null!;
        public PaymentStatus PurchaseStatus { get; set; }
        public int CartID { get; set; }
        public Cart Cart { get; set; } = null!;
        List<DisountsInfo> Discounts { get; set; } = null!;

    }

}
