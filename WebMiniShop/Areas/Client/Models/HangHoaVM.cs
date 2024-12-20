namespace FoodShop.Models;

public class HangHoaVM
{
    public int MaHH { get; set; }
    public string TenHH { get; set; }
    public string Hinh { get; set; }
    public DateTime NgaySX { get; set; }
    public float DonGia { get; set; }
    public string MoTa { get; set; }
    public float GiamGia { get; set; }
    public int SoLanXem { get; set; }
    public int MaLoai { get; set; }
    public string TenLoai { get; set; }
    public float? DonGiaChuaGiam { get; set; }
}

public class ChiTietHangHoaVM
{
    public int MaHH { get; set; }
    public string TenHH { get; set; }
    public string Hinh { get; set; }
    public DateTime NgaySX { get; set; }
    public float DonGia { get; set; }
    public string MoTa { get; set; }
    public float GiamGia { get; set; }
    public int MaLoai { get; set; }
    public string TenLoai { get; set; }
    public int SoLuongTon { get; set; }
    public int DanhGia { get; set; }
}
