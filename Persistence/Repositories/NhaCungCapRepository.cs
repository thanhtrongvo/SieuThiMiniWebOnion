using Application.Features.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class NhaCungCapRepository : INhaCungCapService
    {
        private readonly Hshop2023Context _context;

        public NhaCungCapRepository(Hshop2023Context context)
        {
            _context = context;
        }

        // Lấy danh sách tất cả nhà cung cấp
        public async Task<IEnumerable<NhaCungCap>> GetAllAsync()
        {
            return await _context.NhaCungCaps.ToListAsync();
        }

        // Lấy nhà cung cấp theo ID
        public async Task<NhaCungCap> GetByIdAsync(int id)
        {
            return await _context.NhaCungCaps.FindAsync(id);
        }

        // Thêm nhà cung cấp mới
        public async Task AddAsync(NhaCungCap nhaCungCap)
        {
            await _context.NhaCungCaps.AddAsync(nhaCungCap);
            await _context.SaveChangesAsync();
        }

        // Cập nhật nhà cung cấp
        public async Task UpdateAsync(NhaCungCap nhaCungCap)
        {
            _context.NhaCungCaps.Update(nhaCungCap);
            await _context.SaveChangesAsync();
        }

        // Xóa nhà cung cấp theo ID
        public async Task DeleteAsync(int id)
        {
            var nhaCungCap = await _context.NhaCungCaps.FindAsync(id);
            if (nhaCungCap != null)
            {
                _context.NhaCungCaps.Remove(nhaCungCap);
                await _context.SaveChangesAsync();
            }
        }
    }
}
