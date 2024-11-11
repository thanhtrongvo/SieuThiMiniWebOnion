using Application.Features.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
[Area("Admin")]
public class TrangThaiController : Controller
{
    private readonly ITrangThaiService _trangThaiService;

    public TrangThaiController(ITrangThaiService trangThaiService)
    {
        _trangThaiService = trangThaiService;
    }

    public async Task<IActionResult> Index()
    {
        var trangThais = await _trangThaiService.GetAllTrangThaiAsync();
        return View(trangThais);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(TrangThai trangThai)
    {
        if (ModelState.IsValid)
        {
            await _trangThaiService.CreateTrangThaiAsync(trangThai);
            return RedirectToAction("Index");
        }
        return View(trangThai);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var trangThai = await _trangThaiService.GetTrangThaiByIdAsync(id);
        if (trangThai == null)
        {
            return NotFound();
        }
        return View(trangThai);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(TrangThai trangThai)
    {
        if (ModelState.IsValid)
        {
            await _trangThaiService.UpdateTrangThaiAsync(trangThai);
            return RedirectToAction("Index");
        }
        return View(trangThai);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var trangThai = await _trangThaiService.GetTrangThaiByIdAsync(id);
        if (trangThai == null)
        {
            return NotFound();
        }
        return View(trangThai);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _trangThaiService.DeleteTrangThaiAsync(id);
        return RedirectToAction("Index");
    }
}
