using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interface
{
    public interface IChiTietKhuyenMaiService
    {
        Task<IEnumerable<ChiTietKhuyenMai>> GetAllChiTietKhuyenMaiAsync();
        Task<ChiTietKhuyenMai> GetChiTietKhuyenMaiByIdAsync(int id);
        Task CreateChiTietKhuyenMaiAsync(ChiTietKhuyenMai ChiTietKhuyenMai);
        Task UpdateChiTietKhuyenMaiAsync(ChiTietKhuyenMai ChiTietKhuyenMai);
        Task DeleteChiTietKhuyenMaiAsync(int id);
 
    }
}
