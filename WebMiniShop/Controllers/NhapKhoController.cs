using Application.Features.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebMiniShop.Controllers
{
    public class NhapKhoController : Controller
    {
        private readonly INhapKhoService _nhapKhoService;
        private readonly IHangHoaService _hangHoaService;
        private readonly INhaCungCapService _nhaCungCapService;

        public NhapKhoController(INhapKhoService nhapKhoService, IHangHoaService hangHoaService, INhaCungCapService nhaCungCapService)
        {
            _nhapKhoService = nhapKhoService;
            _hangHoaService = hangHoaService;
            _nhaCungCapService = nhaCungCapService;
        }

        // Hiển thị danh sách Nhập Kho
        public async Task<IActionResult> Index()
        {
            var nhapKho = await _nhapKhoService.GetAll();
            return View(nhapKho);
        }

        // Hiển thị form tạo mới
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.HangHoas = await _hangHoaService.GetAll();
            ViewBag.NhaCungCaps = await _nhaCungCapService.GetAllAsync();
            return View();
        }

        // Xử lý tạo mới Nhập Kho
        [HttpPost]
        public async Task<IActionResult> Create(NhapKho nhapKho)
        {
            if (ModelState.IsValid)
            {
                await _nhapKhoService.Add(nhapKho);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.HangHoas = await _hangHoaService.GetAll();
            ViewBag.NhaCungCaps = await _nhaCungCapService.GetAllAsync();
            return View(nhapKho);
        }

        // Hiển thị form chỉnh sửa
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var nhapKho = await _nhapKhoService.GetById(id);
            if (nhapKho == null)
            {
                return NotFound();
            }
            ViewBag.HangHoas = await _hangHoaService.GetAll();
            ViewBag.NhaCungCaps = await _nhaCungCapService.GetAllAsync();
            return View(nhapKho);
        }

        // Xử lý cập nhật Nhập Kho
        [HttpPost]
        public async Task<IActionResult> Edit(NhapKho nhapKho)
        {
            if (ModelState.IsValid)
            {
                await _nhapKhoService.Update(nhapKho);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.HangHoas = await _hangHoaService.GetAll();
            ViewBag.NhaCungCaps = await _nhaCungCapService.GetAllAsync();
            return View(nhapKho);
        }

        // Xử lý xóa Nhập Kho
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var nhapKho = await _nhapKhoService.GetById(id);
            if (nhapKho == null)
            {
                return NotFound();
            }
            return View(nhapKho);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _nhapKhoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
