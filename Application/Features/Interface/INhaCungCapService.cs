using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.Interface
{
    public interface INhaCungCapService
    {
        Task<IEnumerable<NhaCungCap>> GetAllAsync();  // Lấy tất cả các nhà cung cấp
        Task<NhaCungCap> GetByIdAsync(int id);        // Lấy nhà cung cấp theo ID
        Task AddAsync(NhaCungCap nhaCungCap);         // Thêm nhà cung cấp mới
        Task UpdateAsync(NhaCungCap nhaCungCap);      // Cập nhật nhà cung cấp
        Task DeleteAsync(int id);                     // Xóa nhà cung cấp theo ID
    }
}
