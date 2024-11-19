using Microsoft.AspNetCore.Mvc;
using Domain.Entities; // Đường dẫn namespace cho đúng với cấu trúc dự án của bạn
using Application.Features.Interface;
using System.Threading.Tasks;
[Area("Admin")]
public class LoaiController : Controller
{
    private readonly ILoaiService _loaiService;

    public LoaiController(ILoaiService loaiService)
    {
        _loaiService = loaiService;
    }

    // Hiển thị danh sách loại hàng hóa
    public async Task<IActionResult> Index()
    {
        var loais = await _loaiService.GetAll();
        return View(loais);
    }

    // Hiển thị form thêm loại hàng hóa mới
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // Xử lý thêm loại hàng hóa mới
    [HttpPost]
    public async Task<IActionResult> Create(Loai loai)
    {
        if (ModelState.IsValid)
        {
            await _loaiService.Add(loai);
            return RedirectToAction("Index");
        }
        return View(loai);
    }

    // Hiển thị form chỉnh sửa loại hàng hóa
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var loai = await _loaiService.GetById(id);
        if (loai == null)
        {
            return NotFound();
        }
        return View(loai);
    }

    // Xử lý chỉnh sửa loại hàng hóa
    [HttpPost]
    public async Task<IActionResult> Edit(Loai loai)
    {
        if (ModelState.IsValid)
        {
            await _loaiService.Update(loai);
            return RedirectToAction("Index");
        }
        return View(loai);
    }

    // Hiển thị form xóa loại hàng hóa
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var loai = await _loaiService.GetById(id);
        if (loai == null)
        {
            return NotFound();
        }
        return View(loai);
    }

    // Xử lý xóa loại hàng hóa
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _loaiService.Delete(id);
        return RedirectToAction("Index");
    }
}
