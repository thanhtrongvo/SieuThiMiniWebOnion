using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Features.Interface; // Thêm đường dẫn đến interface của service
using System.Threading.Tasks;
using WebMiniShop.Areas.Client.Helper;
[Area("Admin")]
public class HangHoaController : Controller
{
    private readonly IHangHoaService _hangHoaService;
    private readonly ILoaiService _loaiService; // Thêm service cho loại hàng hóa

    public HangHoaController(IHangHoaService hangHoaService, ILoaiService loaiService)
    {
        _hangHoaService = hangHoaService;
        _loaiService = loaiService;
    }

    // Hiển thị danh sách hàng hóa
    public async Task<IActionResult> Index()
    {
        var hangHoas = await _hangHoaService.GetAll();
        return View(hangHoas);
    }

    // Hiển thị form thêm hàng hóa mới
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Loai = await _loaiService.GetAll(); // Lấy danh sách loại hàng hóa
        return View();
    }

     [HttpPost]
    public async Task<IActionResult> Create(HangHoa hangHoa, IFormFile Hinh)
    {
        if (ModelState.IsValid)
        {
            if (Hinh != null)
            {
                var fileName = MyUtil.UploadHinh(Hinh, "HangHoa");
                hangHoa.Hinh = fileName;
            }

            await _hangHoaService.Add(hangHoa);
            return RedirectToAction("Index");
        }

        ViewBag.Loai = await _loaiService.GetAll();
        return View(hangHoa);
    }


    // Hiển thị form chỉnh sửa hàng hóa
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var hangHoa = await _hangHoaService.GetById(id);
        if (hangHoa == null)
        {
            return NotFound();
        }
        ViewBag.Loai = await _loaiService.GetAll(); // Lấy danh sách loại để hiển thị trong form
        return View(hangHoa);
    }

    // Xử lý chỉnh sửa hàng hóa
    [HttpPost]
    public async Task<IActionResult> Edit(HangHoa hangHoa, IFormFile NewHinh)
    {
        if (ModelState.IsValid)
        {
            if (NewHinh != null)
            {
                var fileName = MyUtil.UploadHinh(NewHinh, "HangHoa");
                hangHoa.Hinh = fileName;
            }

            await _hangHoaService.Update(hangHoa);
            return RedirectToAction("Index");
        }

        ViewBag.Loai = await _loaiService.GetAll();
        return View(hangHoa);
    }

    // Hiển thị form xóa hàng hóa
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var hangHoa = await _hangHoaService.GetById(id);
        if (hangHoa == null)
        {
            return NotFound();
        }
        return View(hangHoa);
    }

    // Xử lý xóa hàng hóa
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _hangHoaService.Delete(id); // Xóa dữ liệu
        return RedirectToAction("Index");
    }
}
