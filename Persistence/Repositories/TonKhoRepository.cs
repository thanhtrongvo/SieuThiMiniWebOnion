using Application.Features.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class TonKhoRepository : ITonKhoService
    {
        private readonly Hshop2023Context _context;

        public TonKhoRepository(Hshop2023Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TonKho>> GetAllTonKhoAsync()
        {
            return await _context.TonKhos
                .Include(t => t.HangHoa) // Bao gồm cả thông tin hàng hóa liên quan
                .ToListAsync();
        }

        public async Task<TonKho> GetTonKhoByIdAsync(int id)
        {
            return await _context.TonKhos
                .Include(t => t.HangHoa)
                .FirstOrDefaultAsync(t => t.MaHH == id);
        }

        public async Task CreateTonKhoAsync(TonKho tonKho)
        {
            _context.TonKhos.Add(tonKho);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTonKhoAsync(TonKho tonKho)
        {
            var existingTonKho = await _context.TonKhos.FindAsync(tonKho.MaHH);
            if (existingTonKho != null)
            {
                existingTonKho.SoLuongTon = tonKho.SoLuongTon;
                existingTonKho.NgayCapNhat = tonKho.NgayCapNhat;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTonKhoAsync(int id)
        {
            var tonKho = await _context.TonKhos.FindAsync(id);
            if (tonKho != null)
            {
                _context.TonKhos.Remove(tonKho);
                await _context.SaveChangesAsync();
            }
        }
    }
}
