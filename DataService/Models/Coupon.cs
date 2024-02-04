using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataService.Models
{
    public class Coupon
    {
        public int CouponId { get; set; }

        public string CouponName { get; set; } = null!;
        public CouponType CouponType { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal Quantity { get; set; }
        public CouponStatus Status { get; set; }
    }
}