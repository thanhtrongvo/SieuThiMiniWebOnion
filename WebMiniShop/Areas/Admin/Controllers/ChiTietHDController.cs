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

    // Hiển thị danh sách chi tiết hóa đơn
    public async Task<IActionResult> Details(int id)
    {
        var chiTietHDs = await _chiTietHDService.GetAllChiTietHDAsync();
        return View(chiTietHDs);
    }

    // Hiển thị form thêm chi tiết hóa đơn mới
    [HttpGet]
    public async Task<IActionResult> Create()
    {
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
            return RedirectToAction("Index");
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

    // Xử lý chỉnh sửa chi tiết hóa đơn
    [HttpPost]
    public async Task<IActionResult> Edit(ChiTietHD chiTietHD)
    {
        if (ModelState.IsValid)
        {
            await _chiTietHDService.UpdateChiTietHDAsync(chiTietHD);
            return RedirectToAction("Index");
        }
        ViewBag.HangHoas = await _hangHoaService.GetAll();
        return View(chiTietHD);
    }

    // Hiển thị form xóa chi tiết hóa đơn
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

    // Xử lý xóa chi tiết hóa đơn
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _chiTietHDService.DeleteChiTietHDAsync(id);
        return RedirectToAction("Index");
    }
}
