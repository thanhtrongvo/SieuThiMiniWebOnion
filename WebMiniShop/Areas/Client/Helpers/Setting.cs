namespace WebMiniShop.Areas.Client.Helper;

public class Setting
{
    public static string CARTKEY = "cart";
    public static string CLAIM_CUSTOMERID = "CustomerID";

    public class PaymentType
    {
        public static string COD = "COD";
        public static string Paypal = "Paypal";
        public static string VNPAY = "VnPay";
        public static string MOMO = "MoMo";
        public static string STRIPE = "Stripe";
    }
}