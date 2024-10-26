using Application.Features.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class NhapKhoRepository : INhapKhoService
    {
        private readonly Hshop2023Context _context;

        public NhapKhoRepository(Hshop2023Context context)
        {
            _context = context;
        }

        // Lấy tất cả các bản ghi Nhập Kho
        public async Task<IEnumerable<NhapKho>> GetAll()
        {
            return await _context.NhapKhos
                .Include(nk => nk.NhaCungCap) // Bao gồm thông tin nhà cung cấp
                .Include(nk => nk.HangHoa) // Bao gồm thông tin hàng hóa
                .ToListAsync();
        }

        // Lấy một bản ghi Nhập Kho theo ID
        public async Task<NhapKho> GetById(int id)
        {
            return await _context.NhapKhos
                .Include(nk => nk.NhaCungCap)
                .Include(nk => nk.HangHoa)
                .FirstOrDefaultAsync(nk => nk.MaNK == id);
        }

        // Thêm mới một bản ghi Nhập Kho
        public async Task Add(NhapKho nhapKho)
        {
            _context.NhapKhos.Add(nhapKho);
            await _context.SaveChangesAsync();
        }

        // Cập nhật một bản ghi Nhập Kho
        public async Task Update(NhapKho nhapKho)
        {
            _context.NhapKhos.Update(nhapKho);
            await _context.SaveChangesAsync();
        }

        // Xóa một bản ghi Nhập Kho theo ID
        public async Task Delete(int id)
        {
            var nhapKho = await _context.NhapKhos.FindAsync(id);
            if (nhapKho != null)
            {
                _context.NhapKhos.Remove(nhapKho);
                await _context.SaveChangesAsync();
            }
        }
    }
}
