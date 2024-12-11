namespace FoodShop.Models;

public class LoaiVM
{
    public int MaLoai { get; set; }
    public string TenLoai { get; set; }
    public int SoLuong { get; set; }
    public List<HangHoaVM>? HangHoas { get; set; }
    
}