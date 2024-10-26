using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.Interface
{
    public interface IKhuyenMaiService
    {
        Task<IEnumerable<KhuyenMai>> GetAll();
        Task<KhuyenMai?> GetById(int id);
        Task Add(KhuyenMai khuyenMai);
        Task Update(KhuyenMai khuyenMai);
        Task Delete(int id);
    }
}
