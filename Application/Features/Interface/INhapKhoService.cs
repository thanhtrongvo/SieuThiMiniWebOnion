using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.Interface
{
    public interface INhapKhoService
    {
        Task<IEnumerable<NhapKho>> GetAll();
        Task<NhapKho> GetById(int id);
        Task Add(NhapKho nhapKho);
        Task Update(NhapKho nhapKho);
        Task Delete(int id);
    }
}
