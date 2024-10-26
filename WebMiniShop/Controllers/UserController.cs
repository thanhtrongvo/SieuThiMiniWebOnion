using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Interface;  // Sử dụng interface thay vì trực tiếp dùng repository
using System.Threading.Tasks;

namespace WebMiniShop.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Action để hiển thị form thêm người dùng
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Action để xử lý việc thêm người dùng
        [HttpPost]
        public async Task<IActionResult> Create(User model)
        {
            if (ModelState.IsValid)
            {
                await _userService.Add(model);  // Sử dụng _userService.Add
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Action để hiển thị danh sách người dùng
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAll();  // Sử dụng _userService.GetAll
            return View(users);
        }

        // Action để hiển thị form sửa người dùng
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userService.GetById(id);  // Lấy người dùng theo ID
            if (user == null)
            {
                return NotFound();
            }
            return View(user);  // Trả về view chỉnh sửa người dùng
        }

        // Action để xử lý việc sửa người dùng
        [HttpPost]
        public async Task<IActionResult> Edit(User model)
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

            // Nếu hợp lệ, cập nhật người dùng
            await _userService.Update(model);
            return RedirectToAction("Index");
        }

        // Action để xác nhận việc xóa người dùng
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetById(id);  // Sử dụng _userService.GetById
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // Action để xử lý việc xóa người dùng
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userService.Delete(id);  // Sử dụng _userService.Delete
            return RedirectToAction("Index");
        }
    }
}
