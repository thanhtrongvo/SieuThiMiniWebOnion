using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.Interface
{
    public interface ITonKhoService
    {
        Task<IEnumerable<TonKho>> GetAllTonKhoAsync();
        Task<TonKho> GetTonKhoByIdAsync(int id);
        Task<TonKho> GetTonKhoByMaHHAsync(int maHH); 
        Task CreateTonKhoAsync(TonKho tonKho);
        Task UpdateTonKhoAsync(TonKho tonKho);
        Task DeleteTonKhoAsync(int id);
    }
}
