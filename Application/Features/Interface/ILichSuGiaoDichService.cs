using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.Interface
{
    public interface ILichSuGiaoDichService
    {
        Task<IEnumerable<LichSuGiaoDich>> GetAll();
        Task<LichSuGiaoDich> GetById(int id);
        Task Add(LichSuGiaoDich lichSuGiaoDich);
        Task Update(LichSuGiaoDich lichSuGiaoDich);
        Task Delete(int id);
    }
}
