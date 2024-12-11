using System;

namespace FoodShop.Models
{
    public class PaymentSuccessVM
    {
        public int OrderId { get; set; }
        public float TotalPrice { get; set; }
        public DateTime PaymentTime { get; set; }
        public string TransactionId { get; set; }
    }
}
