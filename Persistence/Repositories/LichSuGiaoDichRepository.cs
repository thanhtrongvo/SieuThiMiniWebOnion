using Application.Features.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class LichSuGiaoDichRepository : ILichSuGiaoDichService
    {
        private readonly Hshop2023Context _context;

        public LichSuGiaoDichRepository(Hshop2023Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LichSuGiaoDich>> GetAll()
        {
            return await _context.LichSuGiaoDiches
                .Include(l => l.User)
                .Include(l => l.HoaDon)
                .ToListAsync();
        }

        public async Task<LichSuGiaoDich> GetById(int id)
        {
            return await _context.LichSuGiaoDiches
                .Include(l => l.User)
                .Include(l => l.HoaDon)
                .FirstOrDefaultAsync(l => l.MaGiaoDich == id);
        }

        public async Task Add(LichSuGiaoDich lichSuGiaoDich)
        {
            _context.LichSuGiaoDiches.Add(lichSuGiaoDich);
            await _context.SaveChangesAsync();
        }

        public async Task Update(LichSuGiaoDich lichSuGiaoDich)
        {
            _context.LichSuGiaoDiches.Update(lichSuGiaoDich);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var lichSuGiaoDich = await _context.LichSuGiaoDiches.FindAsync(id);
            if (lichSuGiaoDich != null)
            {
                _context.LichSuGiaoDiches.Remove(lichSuGiaoDich);
                await _context.SaveChangesAsync();
            }
        }
    }
}
