using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entities;
namespace WebMiniShop.Models
{
    public class TonKhoViewModel
    {
        public int MaHH { get; set; } // Mã hàng hóa
        public int SoLuongTon { get; set; } // Số lượng tồn kho
        public DateTime NgayCapNhat { get; set; } // Ngày cập nhật
        public List<SelectListItem> HangHoas { get; set; } // Danh sách hàng hóa cho combo box
    }

}
