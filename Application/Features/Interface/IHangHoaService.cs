using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interface
{
    public interface IHangHoaService
    {
        Task<IEnumerable<HangHoa>> GetAll();
        Task<HangHoa> GetById(int id);
        Task Add(HangHoa hangHoa);
        Task Update(HangHoa hangHoa);
        Task Delete(int id);
    }
}
