using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interface
{
    public interface ILoaiService
    {
        Task<IEnumerable<Loai>> GetAll();
        Task<Loai> GetById(int id);
        Task Add(Loai loai);
        Task Update(Loai loai);
        Task Delete(int id);
    }
}
