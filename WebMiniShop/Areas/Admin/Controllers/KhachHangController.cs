using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Interface;  // Sử dụng interface thay vì trực tiếp dùng repository
using System.Threading.Tasks;

namespace WebMiniShop.Controllers
{
    [Area("Admin")]
    public class KhachHangController : Controller
    {
        private readonly IKhachHangService _khachHangService;

        public KhachHangController(IKhachHangService khachHangService)
        {
            _khachHangService = khachHangService;
        }

        // Action để hiển thị form thêm khách hàng
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Action để xử lý việc thêm khách hàng
        [HttpPost]
        public async Task<IActionResult> Create(KhachHang model)
        {
            if (ModelState.IsValid)
            {
                await _khachHangService.Add(model);  // Sử dụng _khachHangService.Add
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Action để hiển thị danh sách khách hàng
        public async Task<IActionResult> Index()
        {
            var khachHangs = await _khachHangService.GetAll();  // Sử dụng _khachHangService.GetAll
            return View(khachHangs);
        }

        // Action để hiển thị form sửa khách hàng
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var khachHang = await _khachHangService.GetById(id);  // Lấy khách hàng theo ID
            if (khachHang == null)
            {
                return NotFound();
            }
            return View(khachHang);  // Trả về view chỉnh sửa khách hàng
        }

        // Action để xử lý việc sửa khách hàng
        [HttpPost]
        public async Task<IActionResult> Edit(KhachHang model)
        {
            if (!ModelState.IsValid)  // Kiểm tra nếu ModelState không hợp lệ
            {
                // Ghi log lỗi hoặc kiểm tra chi tiết ModelState để tìm nguyên nhân
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                return View(model);  // Hiển thị lại form nếu có lỗi
            }

            // Nếu hợp lệ, cập nhật khách hàng
            await _khachHangService.Update(model);
            return RedirectToAction("Index");
        }

        // Action để xác nhận việc xóa khách hàng
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var khachHang = await _khachHangService.GetById(id);  // Sử dụng _khachHangService.GetById
            if (khachHang == null)
            {
                return NotFound();
            }
            return View(khachHang);
        }

        // Action để xử lý việc xóa khách hàng
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _khachHangService.Delete(id);  // Sử dụng _khachHangService.Delete
            return RedirectToAction("Index");
        }
    }
}
