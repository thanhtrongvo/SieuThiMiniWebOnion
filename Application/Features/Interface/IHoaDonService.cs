using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interface
{
    public interface IHoaDonService
    {
        Task<IEnumerable<HoaDon>> GetAll();
        Task<HoaDon> GetById(int id);
        Task Add(HoaDon hoaDon);
        Task Update(HoaDon hoaDon);
        Task Delete(int id);
    }
}
