using Application.Features.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebMiniShop.Controllers
{
    [Area("Admin")]
    public class NhapKhoController : Controller
    {
        private readonly INhapKhoService _nhapKhoService;
        private readonly IHangHoaService _hangHoaService;
        private readonly INhaCungCapService _nhaCungCapService;
        private readonly ITonKhoService _tonKhoService;

        public NhapKhoController(INhapKhoService nhapKhoService, IHangHoaService hangHoaService, INhaCungCapService nhaCungCapService, ITonKhoService tonKhoService)
        {
            _nhapKhoService = nhapKhoService;
            _hangHoaService = hangHoaService;
            _nhaCungCapService = nhaCungCapService;
            _tonKhoService = tonKhoService;
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
        // Xử lý tạo mới Nhập Kho
        [HttpPost]
        public async Task<IActionResult> Create(NhapKho nhapKho)
        {
            if (ModelState.IsValid)
            {
                // Thêm phiếu nhập kho vào cơ sở dữ liệu
                await _nhapKhoService.Add(nhapKho);

                // Kiểm tra tồn kho cho sản phẩm
                var tonKho = await _tonKhoService.GetTonKhoByMaHHAsync(nhapKho.MaHH); // Lấy thông tin tồn kho

                if (tonKho != null)
                {
                    // Nếu tồn kho đã có, cộng số lượng nhập vào
                    tonKho.SoLuongTon += nhapKho.SoLuong;
                    tonKho.NgayCapNhat = DateTime.Now; // Cập nhật ngày giờ cập nhật tồn kho
                    await _tonKhoService.UpdateTonKhoAsync(tonKho); // Lưu thay đổi tồn kho
                }
                else
                {
                    // Nếu chưa có tồn kho cho sản phẩm này, tạo mới tồn kho
                    var newTonKho = new TonKho
                    {
                        MaHH = nhapKho.MaHH,
                        SoLuongTon = nhapKho.SoLuong, // Số lượng nhập kho là số lượng tồn kho ban đầu
                        NgayCapNhat = DateTime.Now
                    };
                    await _tonKhoService.CreateTonKhoAsync(newTonKho); // Thêm mới tồn kho
                }

                return RedirectToAction(nameof(Index));
            }

            // Nếu có lỗi, truyền lại dữ liệu cho form
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
