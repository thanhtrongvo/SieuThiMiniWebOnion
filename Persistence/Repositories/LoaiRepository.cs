using Application.Features.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class LoaiRepository : ILoaiService
    {
        private readonly Hshop2023Context _context;

        public LoaiRepository(Hshop2023Context context)
        {
            _context = context;
        }

        // Triển khai phương thức GetAll để lấy danh sách từ DB
        public async Task<IEnumerable<Loai>> GetAll()
        {
            return await _context.Loais.ToListAsync();  // Loaiss là DbSet trong DbContext
        }

        public async Task<Loai> GetById(int id)
        {
            return await _context.Loais.FindAsync(id);
        }

        public async Task Add(Loai loai)
        {
            _context.Loais.Add(loai);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Loai loai)
        {
            _context.Loais.Update(loai);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var loai = await _context.Loais.FindAsync(id);
            if (loai != null)
            {
                _context.Loais.Remove(loai);
                await _context.SaveChangesAsync();
            }
        }
    }
}
