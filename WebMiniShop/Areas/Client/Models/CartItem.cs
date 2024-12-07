namespace FoodShop.Models;

public class CartItem
{
    public int MaHH { get; set; }
    public string TenHH { get; set; }
    public string Hinh { get; set; }
    public float DonGia { get; set; }
    public int SoLuong { get; set; }
    public float ThanhTien => DonGia * SoLuong;
}