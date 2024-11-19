using Application.Features.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
[Area("Admin")]
public class TonKhoController : Controller
{
    private readonly ITonKhoService _tonKhoService;

    public TonKhoController(ITonKhoService tonKhoService)
    {
        _tonKhoService = tonKhoService;
    }

    public async Task<IActionResult> Index()
    {
        var tonKhos = await _tonKhoService.GetAllTonKhoAsync();
        return View(tonKhos);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(TonKho tonKho)
    {
        if (ModelState.IsValid)
        {
            await _tonKhoService.CreateTonKhoAsync(tonKho);
            return RedirectToAction("Index");
        }
        return View(tonKho);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var tonKho = await _tonKhoService.GetTonKhoByIdAsync(id);
        if (tonKho == null)
        {
            return NotFound();
        }
        return View(tonKho);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(TonKho tonKho)
    {
        if (ModelState.IsValid)
        {
            await _tonKhoService.UpdateTonKhoAsync(tonKho);
            return RedirectToAction("Index");
        }
        return View(tonKho);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var tonKho = await _tonKhoService.GetTonKhoByIdAsync(id);
        if (tonKho == null)
        {
            return NotFound();
        }
        return View(tonKho);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _tonKhoService.DeleteTonKhoAsync(id);
        return RedirectToAction("Index");
    }
}
