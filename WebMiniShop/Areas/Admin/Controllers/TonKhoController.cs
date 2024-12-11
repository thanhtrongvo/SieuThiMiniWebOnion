using System.Threading.Tasks;
using Application.Features.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
}
