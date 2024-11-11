using Application.Features.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebMiniShop.Controllers
{
    [Area("Admin")]
    public class LichSuGiaoDichController : Controller
    {
        private readonly ILichSuGiaoDichService _lichSuGiaoDichService;
        private readonly IUserService _userService;
        private readonly IHoaDonService _hoaDonService;

        public LichSuGiaoDichController(ILichSuGiaoDichService lichSuGiaoDichService, IUserService userService, IHoaDonService hoaDonService)
        {
            _lichSuGiaoDichService = lichSuGiaoDichService;
            _userService = userService;
            _hoaDonService = hoaDonService;
        }

        public async Task<IActionResult> Index()
        {
            var lichSuGiaoDiches = await _lichSuGiaoDichService.GetAll();
            return View(lichSuGiaoDiches);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Users = await _userService.GetAll();
            ViewBag.HoaDons = await _hoaDonService.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LichSuGiaoDich lichSuGiaoDich)
        {
            if (ModelState.IsValid)
            {
                await _lichSuGiaoDichService.Add(lichSuGiaoDich);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Users = await _userService.GetAll();
            ViewBag.HoaDons = await _hoaDonService.GetAll();
            return View(lichSuGiaoDich);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var lichSuGiaoDich = await _lichSuGiaoDichService.GetById(id);
            if (lichSuGiaoDich == null) return NotFound();

            ViewBag.Users = await _userService.GetAll();
            ViewBag.HoaDons = await _hoaDonService.GetAll();
            return View(lichSuGiaoDich);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LichSuGiaoDich lichSuGiaoDich)
        {
            if (ModelState.IsValid)
            {
                await _lichSuGiaoDichService.Update(lichSuGiaoDich);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Users = await _userService.GetAll();
            ViewBag.HoaDons = await _hoaDonService.GetAll();
            return View(lichSuGiaoDich);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var lichSuGiaoDich = await _lichSuGiaoDichService.GetById(id);
            if (lichSuGiaoDich == null) return NotFound();
            return View(lichSuGiaoDich);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _lichSuGiaoDichService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
