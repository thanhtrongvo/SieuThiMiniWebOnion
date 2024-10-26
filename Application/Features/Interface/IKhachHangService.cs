using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interface
{
    public interface IKhachHangService
    {
        Task<IEnumerable<KhachHang>> GetAll();
        Task<KhachHang> GetById(int id);
        Task Add(KhachHang khachHang);
        Task Update(KhachHang khachHang);
        Task Delete(int id);
    }

}
