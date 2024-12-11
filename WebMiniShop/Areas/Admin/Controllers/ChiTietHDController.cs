using Application.Features.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Threading.Tasks;
[Area("Admin")]
public class ChiTietHDController : Controller
{
    private readonly IChiTietHDService _chiTietHDService;
    private readonly IHangHoaService _hangHoaService;

    public ChiTietHDController(IChiTietHDService chiTietHDService, IHangHoaService hangHoaService)
    {
        _chiTietHDService = chiTietHDService;
        _hangHoaService = hangHoaService;
    }

    // Hiển thị danh sách chi tiết hóa đơn của một hóa đơn cụ thể
    public async Task<IActionResult> Details(int id)
    {
        var chiTietHDs = await _chiTietHDService.GetAllChiTietHDAsync();
        var chiTietHoaDon = chiTietHDs.Where(c => c.MaHD == id).ToList(); // Lọc theo MaHD
        return View(chiTietHoaDon);
    }

    // Hiển thị form thêm chi tiết hóa đơn mới
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        // Tải danh sách hàng hóa và hóa đơn
        ViewBag.HangHoas = await _hangHoaService.GetAll();
        return View();
    }


    // Xử lý thêm chi tiết hóa đơn mới
    [HttpPost]
    public async Task<IActionResult> Create(ChiTietHD chiTietHD)
    {
        if (ModelState.IsValid)
        {
            await _chiTietHDService.CreateChiTietHDAsync(chiTietHD);
            return RedirectToAction("Details", "HoaDon", new { id = chiTietHD.MaHD });  // Quay lại trang chi tiết hóa đơn
        }

        ViewBag.HangHoas = await _hangHoaService.GetAll();
        return View(chiTietHD);
    }



    // Hiển thị form chỉnh sửa chi tiết hóa đơn
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var chiTietHD = await _chiTietHDService.GetChiTietHDByIdAsync(id);
        if (chiTietHD == null)
        {
            return NotFound();
        }

        ViewBag.HangHoas = await _hangHoaService.GetAll();
        return View(chiTietHD);
    }


    [HttpPost]
    public async Task<IActionResult> Edit(ChiTietHD chiTietHD)
    {
        if (ModelState.IsValid)
        {
            await _chiTietHDService.UpdateChiTietHDAsync(chiTietHD);
            return RedirectToAction("Details", "HoaDon", new { id = chiTietHD.MaHD });
        }

        ViewBag.HangHoas = await _hangHoaService.GetAll();
        return View(chiTietHD);
    }

    // Xóa chi tiết hóa đơn
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var chiTietHD = await _chiTietHDService.GetChiTietHDByIdAsync(id);
        if (chiTietHD == null)
        {
            return NotFound();
        }
        return View(chiTietHD);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _chiTietHDService.DeleteChiTietHDAsync(id);
        return RedirectToAction("Index", "HoaDon");
    }
    [HttpGet]
    public async Task<IActionResult> Top10SanPhamBanChay()
    {
        var chiTietHDs = await _chiTietHDService.GetAllChiTietHDAsync();
        var topSanPham = chiTietHDs
            .GroupBy(c => new { c.MaHH, c.HangHoa.TenHH })
            .Select(g => new
            {
                maHH = g.Key.MaHH,
                tenHH = g.Key.TenHH,
                tongSoLuong = g.Sum(c => c.SoLuong)
            })
            .OrderByDescending(x => x.tongSoLuong)
            .Take(10)
            .ToList();

        return Json(topSanPham);
    }
    [HttpGet]
    public IActionResult ThongKeTop10()
    {
        // Trả về view hiển thị biểu đồ thống kê
        return View();
    }
    [HttpGet]
 
    public async Task<IActionResult> ExportTop10ToExcel()
    {
        // Lấy dữ liệu top 10 sản phẩm bán chạy
        var chiTietHDs = await _chiTietHDService.GetAllChiTietHDAsync();
        var topSanPham = chiTietHDs
            .GroupBy(c => new { c.MaHH, c.HangHoa.TenHH })
            .Select(g => new
            {
                MaHH = g.Key.MaHH,
                TenHH = g.Key.TenHH,
                TongSoLuong = g.Sum(c => c.SoLuong)
            })
            .OrderByDescending(x => x.TongSoLuong)
            .Take(10)
            .ToList();

        // Thiết lập giấy phép EPPlus
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        // Tạo file Excel
        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("Top10SanPhamBanChay");
            worksheet.Cells[1, 1].Value = "Mã Hàng Hóa";
            worksheet.Cells[1, 2].Value = "Tên Hàng Hóa";
            worksheet.Cells[1, 3].Value = "Tổng Số Lượng Bán";

            for (int i = 0; i < topSanPham.Count; i++)
            {
                worksheet.Cells[i + 2, 1].Value = topSanPham[i].MaHH;
                worksheet.Cells[i + 2, 2].Value = topSanPham[i].TenHH;
                worksheet.Cells[i + 2, 3].Value = topSanPham[i].TongSoLuong;
            }

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            var stream = new MemoryStream(package.GetAsByteArray());
            var fileName = "Top10SanPhamBanChay.xlsx";
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            return File(stream, contentType, fileName);
        }
    }


}
