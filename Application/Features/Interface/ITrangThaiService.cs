using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interface
{
    public interface ITrangThaiService
    {
        Task<IEnumerable<TrangThai>> GetAllTrangThaiAsync();
        Task<TrangThai> GetTrangThaiByIdAsync(int id);
        Task CreateTrangThaiAsync(TrangThai trangThai);
        Task UpdateTrangThaiAsync(TrangThai trangThai);
        Task DeleteTrangThaiAsync(int id);
    }
}
