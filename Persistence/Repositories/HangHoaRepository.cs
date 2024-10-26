using Application.Features.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class HangHoaRepository : IHangHoaService
    {
        private readonly Hshop2023Context _context;

        public HangHoaRepository(Hshop2023Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HangHoa>> GetAll()
        {
            return await _context.HangHoas.Include(h => h.Loai).ToListAsync(); // Include để lấy thông tin loại
        }

        public async Task<HangHoa> GetById(int id)
        {
            return await _context.HangHoas.FindAsync(id);
        }

        public async Task Add(HangHoa hangHoa)
        {
            _context.HangHoas.Add(hangHoa);
            await _context.SaveChangesAsync();
        }

        public async Task Update(HangHoa hangHoa)
        {
            _context.HangHoas.Update(hangHoa);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var hangHoa = await _context.HangHoas.FindAsync(id);
            if (hangHoa != null)
            {
                _context.HangHoas.Remove(hangHoa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
