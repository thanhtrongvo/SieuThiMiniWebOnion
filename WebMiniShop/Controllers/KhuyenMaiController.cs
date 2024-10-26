using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Interface; // Sử dụng interface thay vì trực tiếp dùng repository
using System.Threading.Tasks;

namespace WebMiniShop.Controllers
{
    public class KhuyenMaiController : Controller
    {
        private readonly IKhuyenMaiService _khuyenMaiService;

        public KhuyenMaiController(IKhuyenMaiService khuyenMaiService)
        {
            _khuyenMaiService = khuyenMaiService;
        }

        // Hiển thị form thêm khuyến mãi
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Xử lý thêm khuyến mãi
        [HttpPost]
        public async Task<IActionResult> Create(KhuyenMai model)
        {
            if (ModelState.IsValid)
            {
                await _khuyenMaiService.Add(model); // Sử dụng _khuyenMaiService.Add
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Hiển thị danh sách khuyến mãi
        public async Task<IActionResult> Index()
        {
            var khuyenMais = await _khuyenMaiService.GetAll(); // Sử dụng _khuyenMaiService.GetAll
            return View(khuyenMais);
        }

        // Hiển thị form sửa khuyến mãi
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var khuyenMai = await _khuyenMaiService.GetById(id); // Lấy khuyến mãi theo ID
            if (khuyenMai == null)
            {
                return NotFound();
            }
            return View(khuyenMai); // Trả về view chỉnh sửa khuyến mãi
        }

        // Xử lý việc sửa khuyến mãi
        [HttpPost]
        public async Task<IActionResult> Edit(KhuyenMai model)
        {
            if (!ModelState.IsValid) // Kiểm tra nếu ModelState không hợp lệ
            {
                return View(model);
            }

            await _khuyenMaiService.Update(model);
            return RedirectToAction("Index");
        }

        // Hiển thị form xóa khuyến mãi
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var khuyenMai = await _khuyenMaiService.GetById(id); // Sử dụng _khuyenMaiService.GetById
            if (khuyenMai == null)
            {
                return NotFound();
            }
            return View(khuyenMai);
        }

        // Xử lý việc xóa khuyến mãi
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _khuyenMaiService.Delete(id); // Sử dụng _khuyenMaiService.Delete
            return RedirectToAction("Index");
        }
    }
}
