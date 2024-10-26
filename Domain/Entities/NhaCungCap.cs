using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("NhaCungCap")]
    public class NhaCungCap
    {
        [Key]
        public int MaNCC { get; set; }

       
        [StringLength(255)]
        [Display(Name = "Tên Nhà Cung Cấp")]
        public string? TenNCC { get; set; }

   
        [StringLength(255)]
        [Display(Name = "Địa Chỉ")]
        public string? DiaChi { get; set; }

      
        [StringLength(50)]
        [Display(Name = "Điện Thoại")]
        public  string? DienThoai { get; set; }

        [StringLength(255)]
        public  string? Email { get; set; }

        [StringLength(255)]
        public  string? Website { get; set; }

        public string? GhiChu { get; set; }

        // Navigation Properties
        public ICollection<NhapKho>? NhapKhos { get; set; }
    }
}
