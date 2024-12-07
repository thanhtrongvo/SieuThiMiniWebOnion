using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq;
using System.Threading.Tasks;

namespace WebMiniShop.Controllers
{
    [Area("Admin")]
    public class ThongKeController : Controller
    {
        private readonly Hshop2023Context _context;

        public ThongKeController(Hshop2023Context context)
        {
            _context = context;
        }

        // Thống kê doanh thu theo sản phẩm
        public async Task<IActionResult> DoanhThuTheoSanPham()
        {
            // Tính toán doanh thu cho từng sản phẩm
            var doanhThu = await (from ct in _context.ChiTietHDs
                                  group ct by ct.MaHH into g
                                  select new
                                  {
                                      ProductId = g.Key,
                                      TotalRevenue = g.Sum(x => x.DonGia * x.SoLuong) // Tính doanh thu: Giá bán * Số lượng
                                  })
                                   .ToListAsync();

            // Lấy thông tin tên sản phẩm cùng với doanh thu
            var result = (from dt in doanhThu
                          join hh in _context.HangHoas on dt.ProductId equals hh.MaHH
                          select new
                          {
                              ProductName = hh.TenHH,
                              TotalRevenue = dt.TotalRevenue
                          }).ToList();

            // Trả về dữ liệu JSON cho biểu đồ
            return Json(result);
        }


        // Thống kê khách hàng mua nhiều nhất
        //public async Task<IActionResult> KhachHangMuaNhieuNhat()
        //{
        //    // Truy vấn hóa đơn và chi tiết hóa đơn, tính toán tổng số lượng mua của mỗi khách hàng
        //    var hoaDonQuery = await _context.HoaDons
        //        .SelectMany(hd => hd.ChiTietHDs, (hd, ct) => new { hd.MaUser, ct.SoLuong })
        //        .GroupBy(x => x.MaUser)
        //        .Select(g => new
        //        {
        //            MaKH = g.Key,
        //            TotalQuantity = g.Sum(x => x.SoLuong)
        //        })
        //        .ToListAsync();

        //    // Lấy danh sách khách hàng và kết hợp với kết quả đã tính toán
        //    var result = (from kh in _context.KhachHangs
        //                  join hd in hoaDonQuery
        //                  on kh.ma equals hd.MaKH
        //                  orderby hd.TotalQuantity descending
        //                  select new
        //                  {
        //                      CustomerName = kh.TenKH,
        //                      TotalQuantity = hd.TotalQuantity
        //                  }).Take(10).ToList();

        //    return Json(result);
        //}



        // Thống kê tổng số hóa đơn theo khoảng thời gian
        public async Task<IActionResult> TongSoHoaDon(DateTime? startDate, DateTime? endDate)
        {
            // Nếu không có thời gian, lấy toàn bộ hóa đơn
            if (startDate == null) startDate = DateTime.MinValue;
            if (endDate == null) endDate = DateTime.MaxValue;

            // Tính tổng số hóa đơn trong khoảng thời gian
            var totalInvoices = await _context.HoaDons
                                              .Where(hd => hd.NgayDat >= startDate && hd.NgayDat <= endDate)
                                              .GroupBy(hd => hd.NgayDat.Date)
                                              .Select(g => new
                                              {
                                                  Date = g.Key,
                                                  InvoiceCount = g.Count() // Tính số hóa đơn theo ngày
                                              })
                                              .ToListAsync();

            // Trả về dữ liệu JSON cho biểu đồ
            return Json(totalInvoices);
        }


        // Thống kê doanh thu theo thời gian (theo ngày, tháng, năm)
        public async Task<IActionResult> DoanhThuTheoThoiGian(DateTime? startDate, DateTime? endDate, string timeUnit = "Day")
        {
            if (startDate == null) startDate = DateTime.MinValue;
            if (endDate == null) endDate = DateTime.MaxValue;

            // Bước 1: Tính tổng doanh thu của từng hóa đơn
            var hoaDonQuery = from hd in _context.HoaDons
                              where hd.NgayDat >= startDate && hd.NgayDat <= endDate
                              select new
                              {
                                  hd.MaHD,
                                  hd.NgayDat,
                                  TotalAmount = hd.ChiTietHDs.Sum(ct => ct.DonGia * ct.SoLuong - ct.GiamGia) // Tính tổng doanh thu cho hóa đơn
                              };

            // Bước 2: Nhóm theo thời gian và tính tổng doanh thu của các nhóm
            IQueryable<dynamic> doanhThuQuery;
            switch (timeUnit)
            {
                case "Month":
                    doanhThuQuery = from hd in hoaDonQuery
                                    group hd by new { hd.NgayDat.Year, hd.NgayDat.Month } into g
                                    select new
                                    {
                                        Period = g.Key.Year + "-" + g.Key.Month.ToString("00"),
                                        TotalRevenue = g.Sum(x => x.TotalAmount)
                                    };
                    break;

                case "Year":
                    doanhThuQuery = from hd in hoaDonQuery
                                    group hd by new { hd.NgayDat.Year } into g
                                    select new
                                    {
                                        Period = g.Key.Year.ToString(),
                                        TotalRevenue = g.Sum(x => x.TotalAmount)
                                    };
                    break;

                case "Day":
                default:
                    doanhThuQuery = from hd in hoaDonQuery
                                    group hd by hd.NgayDat.Date into g
                                    select new
                                    {
                                        Period = g.Key.ToString("yyyy-MM-dd"),
                                        TotalRevenue = g.Sum(x => x.TotalAmount)
                                    };
                    break;
            }

            var result = await doanhThuQuery.ToListAsync();

            // Trả kết quả dạng JSON để dễ dàng render bằng Chart.js trong View
            return Json(result);
        }



    }
}
