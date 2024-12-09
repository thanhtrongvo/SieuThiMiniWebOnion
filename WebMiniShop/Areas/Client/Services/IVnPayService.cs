using FoodShop.Models;

namespace WebMiniShop.Areas.Client.Services;

public interface IVnPayService
{
    string CreatePaymentUrl(HttpContext context, VnPaymentRequestModel model);
    VnPaymentResponseModel PaymentExecute(IQueryCollection collections);
}