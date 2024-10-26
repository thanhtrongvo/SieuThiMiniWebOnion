using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interface
{
    public interface IChiTietHDService
    {
        Task<IEnumerable<ChiTietHD>> GetAllChiTietHDAsync();
        Task<ChiTietHD> GetChiTietHDByIdAsync(int id);
        Task CreateChiTietHDAsync(ChiTietHD ChiTietHD);
        Task UpdateChiTietHDAsync(ChiTietHD ChiTietHD);
        Task DeleteChiTietHDAsync(int id);
    }
}
