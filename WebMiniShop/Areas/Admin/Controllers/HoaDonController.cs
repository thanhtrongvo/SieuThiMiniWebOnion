using Application.Features.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Area("Admin")]
public class HoaDonController : Controller
{
    private readonly IHoaDonService _hoaDonService;
    private readonly IChiTietHDService _chiTietHDService;
    private readonly IUserService _userService;
    private readonly ITrangThaiService _trangThaiService;

    public HoaDonController(
        IHoaDonService hoaDonService,
        IChiTietHDService chiTietHDService,
        IUserService userService,
        ITrangThaiService trangThaiService)
    {
        _hoaDonService = hoaDonService;
        _chiTietHDService = chiTietHDService;
        _userService = userService;
        _trangThaiService = trangThaiService;
    }

    // Hiển thị danh sách hóa đơn
    public async Task<IActionResult> Index()
    {
        var hoaDons = await _hoaDonService.GetAll();
        return View(hoaDons);
    }

    // Hiển thị chi tiết hóa đơn (bao gồm danh sách chi tiết hóa đơn)
    public async Task<IActionResult> Details(int id)
    {
        var hoaDon = await _hoaDonService.GetById(id);
        if (hoaDon == null)
        {
            return NotFound();
        }

        var chiTietHDs = await _chiTietHDService.GetAllChiTietHDAsync();
        ViewBag.ChiTietHDs = chiTietHDs.Where(ct => ct.MaHD == id).ToList();

        return View(hoaDon);
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

    // Thống kê top 10 sản phẩm bán chạy
    public IActionResult ThongKeTop10()
    {
        return RedirectToAction("ThongKeTop10", "ChiTietHD");
    }
    [HttpPost]
    public async Task<IActionResult> ProcessOrder(int id)
    {
        var hoaDon = await _hoaDonService.GetById(id);
        if (hoaDon == null)
        {
            return NotFound();
        }

        if (hoaDon.MaTrangThai < 4)
        {
            hoaDon.MaTrangThai++;
            await _hoaDonService.Update(hoaDon);
            return Ok();
        }
        else
        {
            return BadRequest("Hóa đơn đã hoàn tất.");
        }
    }

}
