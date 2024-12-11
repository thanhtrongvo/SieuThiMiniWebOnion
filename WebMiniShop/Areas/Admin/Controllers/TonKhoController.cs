using System.Threading.Tasks;
using Application.Features.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using OfficeOpenXml;
using System.Threading.Tasks;
[Area("Admin")]
public class TonKhoController : Controller
{
    private readonly ITonKhoService _tonKhoService;
    private readonly IHangHoaService _hangHoaService;

    // Constructor nhận service cho cả TonKho và HangHoa
    public TonKhoController(ITonKhoService tonKhoService, IHangHoaService hangHoaService)
    {
        _tonKhoService = tonKhoService;
        _hangHoaService = hangHoaService;
    }

    public async Task<IActionResult> Index()
    {
        var tonKhos = await _tonKhoService.GetAllTonKhoAsync();
        return View(tonKhos);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        // Lấy danh sách hàng hóa từ database
        var hangHoas = await _hangHoaService.GetAll();

        // Kiểm tra nếu danh sách hàng hóa không null và không trống
        if (hangHoas != null)
        {
            ViewBag.HangHoas = hangHoas
                .Select(h => new SelectListItem { Value = h.MaHH.ToString(), Text = h.TenHH })
                .ToList();
        }
        else
        {
            ViewBag.HangHoas = new List<SelectListItem>(); // Nếu không có dữ liệu, gán danh sách trống
        }

        // Khởi tạo đối tượng TonKho với giá trị mặc định
        var tonKho = new TonKho
        {
            SoLuongTon = 0, // Set mặc định số lượng tồn là 0
        };

        return View(tonKho);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TonKho tonKho)
    {
        if (ModelState.IsValid)
        {
            // Kiểm tra xem hàng hóa đã có trong tồn kho chưa
            var existingTonKho = await _tonKhoService.GetTonKhoByMaHHAsync(tonKho.MaHH);
            if (existingTonKho != null)
            {
                // Nếu tồn tại, hiển thị thông báo lỗi
                ModelState.AddModelError("MaHH", "Hàng hóa này đã tồn tại trong kho!");
                return View(tonKho);
            }
            tonKho.MaHH = 0;

            await _tonKhoService.CreateTonKhoAsync(tonKho);
            return RedirectToAction("Index");
        }
        return View(tonKho);
    }


   


    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var tonKho = await _tonKhoService.GetTonKhoByIdAsync(id);
        if (tonKho == null)
        {
            return NotFound();
        }
        return View(tonKho);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(TonKho tonKho)
    {
        if (ModelState.IsValid)
        {
            await _tonKhoService.UpdateTonKhoAsync(tonKho);
            return RedirectToAction("Index");
        }
        return View(tonKho);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var tonKho = await _tonKhoService.GetTonKhoByIdAsync(id);
        if (tonKho == null)
        {
            return NotFound();
        }
        return View(tonKho);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _tonKhoService.DeleteTonKhoAsync(id);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<IActionResult> Stats()
    {
        // Lấy tất cả thông tin về tồn kho
        var tonKhos = await _tonKhoService.GetAllTonKhoAsync();

        // Trả về view với danh sách tồn kho
        return View(tonKhos);
    }
    public async Task<IActionResult> ExportToExcel()
    {
        // Thiết lập LicenseContext
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        // Lấy dữ liệu tồn kho
        var tonKhos = await _tonKhoService.GetAllTonKhoAsync();

        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("Thống Kê Tồn Kho");

            // Thêm tiêu đề cột
            worksheet.Cells[1, 1].Value = "Mã Hàng Hóa";

            worksheet.Cells[1, 2].Value = "Số Lượng Tồn";
            worksheet.Cells[1, 3].Value = "Ngày Cập Nhật";

            // Thêm dữ liệu vào các dòng
            for (int i = 0; i < tonKhos.Count(); i++)
            {
                var tonKho = tonKhos.ElementAt(i);
                worksheet.Cells[i + 2, 1].Value = tonKho.MaHH;
              
                worksheet.Cells[i + 2, 2].Value = tonKho.SoLuongTon;
                worksheet.Cells[i + 2, 3].Value = tonKho.NgayCapNhat?.ToString("dd/MM/yyyy");
            }

            // Xuất file Excel
            var fileContent = package.GetAsByteArray();
            return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TonKho.xlsx");
        }
    }
    [HttpGet]
    public async Task<JsonResult> GetTonKhoData()
    {
        var tonKhos = await _tonKhoService.GetAllTonKhoAsync();

        // Tạo dữ liệu cho biểu đồ
        var data = tonKhos.Select(t => new
        {
            MaHH = t.MaHH, // Mã hàng hóa
            SoLuongTon = t.SoLuongTon ?? 0 // Số lượng tồn kho
        });

        return Json(data);
    }




}
