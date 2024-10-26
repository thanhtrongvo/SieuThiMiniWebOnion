using Application.Features.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebMiniShop.Controllers
{
    public class NhaCungCapController : Controller
    {
        private readonly INhaCungCapService _nhaCungCapService;

        public NhaCungCapController(INhaCungCapService nhaCungCapService)
        {
            _nhaCungCapService = nhaCungCapService;
        }

        // Hiển thị danh sách nhà cung cấp
        public async Task<IActionResult> Index()
        {
            var nhaCungCaps = await _nhaCungCapService.GetAllAsync();
            return View(nhaCungCaps);
        }

        // Hiển thị form thêm nhà cung cấp mới
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Xử lý thêm nhà cung cấp mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NhaCungCap nhaCungCap)
        {
            if (ModelState.IsValid)
            {
                await _nhaCungCapService.AddAsync(nhaCungCap);
                return RedirectToAction("Index");
            }
            return View(nhaCungCap);
        }

        // Hiển thị form chỉnh sửa nhà cung cấp
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var nhaCungCap = await _nhaCungCapService.GetByIdAsync(id);
            if (nhaCungCap == null)
            {
                return NotFound();
            }
            return View(nhaCungCap);
        }

        // Xử lý chỉnh sửa nhà cung cấp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NhaCungCap nhaCungCap)
        {
            if (ModelState.IsValid)
            {
                await _nhaCungCapService.UpdateAsync(nhaCungCap);
                return RedirectToAction(nameof(Index));
            }
            return View(nhaCungCap);
        }

        // Hiển thị form xác nhận xóa nhà cung cấp
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var nhaCungCap = await _nhaCungCapService.GetByIdAsync(id);
            if (nhaCungCap == null)
            {
                return NotFound();
            }
            return View(nhaCungCap);
        }

        // Xử lý xóa nhà cung cấp
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhaCungCap = await _nhaCungCapService.GetByIdAsync(id);
            if (nhaCungCap != null)
            {
                await _nhaCungCapService.GetByIdAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
