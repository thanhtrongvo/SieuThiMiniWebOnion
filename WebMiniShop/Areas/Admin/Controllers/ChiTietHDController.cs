using Application.Features.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
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
}
