using System.ComponentModel.DataAnnotations;

namespace DataService.Models
{
    public class DisountsInfo
    {
        public int PaymentID { get; set; }
        public Payment Payment { get; set; }
        public int CouponId { get; set; }
        public Coupon Coupon { get; set; }
    }
}