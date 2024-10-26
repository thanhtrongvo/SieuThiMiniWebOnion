using Application.Features.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class HoaDonController : Controller
{
    private readonly IHoaDonService _hoaDonService;
    private readonly IChiTietHDService _chiTietHDService;
    private readonly IUserService _userService;
    private readonly ITrangThaiService _trangThaiService;

    public HoaDonController(IHoaDonService hoaDonService, IChiTietHDService chiTietHDService, IUserService userService, ITrangThaiService trangThaiService)
    {
        _hoaDonService = hoaDonService;
        _chiTietHDService = chiTietHDService;
        _userService = userService;
        _trangThaiService = trangThaiService;
    }

    // Hiển thị danh sách hóa đơn và chi tiết hóa đơn
    public async Task<IActionResult> Index()
    {
        var hoaDons = await _hoaDonService.GetAll();
        return View(hoaDons);
    }

    // Hiển thị form thêm hóa đơn mới
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Users = await _userService.GetAll();
        ViewBag.TrangThais = await _trangThaiService.GetAllTrangThaiAsync();
        return View();
    }

    // Xử lý thêm hóa đơn mới
    [HttpPost]
    public async Task<IActionResult> Create(HoaDon hoaDon)
    {
        if (ModelState.IsValid)
        {
            await _hoaDonService.Add(hoaDon);
            return RedirectToAction("Index");
        }
        ViewBag.Users = await _userService.GetAll();
        ViewBag.TrangThais = await _trangThaiService.GetAllTrangThaiAsync();
        return View(hoaDon);
    }

    // Hiển thị form chỉnh sửa hóa đơn
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var hoaDon = await _hoaDonService.GetById(id);
        if (hoaDon == null)
        {
            return NotFound();
        }
        ViewBag.Users = await _userService.GetAll();
        ViewBag.TrangThais = await _trangThaiService.GetAllTrangThaiAsync();
        return View(hoaDon);
    }

    // Xử lý chỉnh sửa hóa đơn
    [HttpPost]
    public async Task<IActionResult> Edit(HoaDon hoaDon)
    {
        if (ModelState.IsValid)
        {
            await _hoaDonService.Update(hoaDon);
            return RedirectToAction("Index");
        }
        ViewBag.Users = await _userService.GetAll();
        ViewBag.TrangThais = await _trangThaiService.GetAllTrangThaiAsync();
        return View(hoaDon);
    }

    // Hiển thị form xóa hóa đơn
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var hoaDon = await _hoaDonService.GetById(id);
        if (hoaDon == null)
        {
            return NotFound();
        }
        return View(hoaDon);
    }

    // Xử lý xóa hóa đơn
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _hoaDonService.Delete(id);
        return RedirectToAction("Index");
    }
}
