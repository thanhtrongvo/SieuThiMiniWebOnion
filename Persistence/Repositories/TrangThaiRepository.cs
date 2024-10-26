using Application.Features.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;

public class TrangThaiRepository : ITrangThaiService
{
    private readonly Hshop2023Context _context;

    public TrangThaiRepository(Hshop2023Context context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TrangThai>> GetAllTrangThaiAsync()
    {
        return await _context.TrangThais.ToListAsync();
    }

    public async Task<TrangThai> GetTrangThaiByIdAsync(int id)
    {
        return await _context.TrangThais.FindAsync(id);
    }

    public async Task CreateTrangThaiAsync(TrangThai trangThai)
    {
        _context.TrangThais.Add(trangThai);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTrangThaiAsync(TrangThai trangThai)
    {
        var existingTrangThai = await _context.TrangThais.FindAsync(trangThai.MaTrangThai);
        if (existingTrangThai != null)
        {
            existingTrangThai.TenTrangThai = trangThai.TenTrangThai;
            existingTrangThai.MoTa = trangThai.MoTa;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteTrangThaiAsync(int id)
    {
        var trangThai = await _context.TrangThais.FindAsync(id);
        if (trangThai != null)
        {
            _context.TrangThais.Remove(trangThai);
            await _context.SaveChangesAsync();
        }
    }
}
