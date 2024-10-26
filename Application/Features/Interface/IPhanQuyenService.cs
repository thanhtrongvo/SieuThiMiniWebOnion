using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interface
{
    public interface IPhanQuyenService
    {
        Task<IEnumerable<PhanQuyen>> GetAllPhanQuyenAsync();
        Task<PhanQuyen> GetPhanQuyenByIdAsync(int id);
        Task CreatePhanQuyenAsync(PhanQuyen PhanQuyen);
        Task UpdatePhanQuyenAsync(PhanQuyen PhanQuyen);
        Task DeletePhanQuyenAsync(int id);
    }
}
