using Domain.Entities;

namespace WebMiniShop.Models
{
    public class NhapKhoViewModel
    {
        public NhapKho NhapKho { get; set; }
        public List<NhaCungCap> NhaCungCaps { get; set; }
        public List<HangHoa> HangHoas { get; set; }
    }

}
