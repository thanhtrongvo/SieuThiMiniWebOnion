using System.ComponentModel.DataAnnotations;

namespace FoodShop.Models;

public class LoginViewModel
{
    [Required] [StringLength(255)] public string Email { get; set; }

    [Required] [StringLength(255)] public string MatKhau { get; set; }
}