using Application.Features.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class PhanQuyenRepository : IPhanQuyenService
    {
        private readonly Hshop2023Context _context;

        public PhanQuyenRepository(Hshop2023Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PhanQuyen>> GetAllPhanQuyenAsync()
        {
            return await _context.PhanQuyens
                .Select(p => new PhanQuyen
                {
                    MaPQ = p.MaPQ,
                    MaNV = p.MaNV,
                    MaTrang = p.MaTrang,
                    Them = p.Them,
                    Sua = p.Sua,
                    Xoa = p.Xoa,
                    Xem = p.Xem
                })
                .ToListAsync();
        }

        public async Task<PhanQuyen> GetPhanQuyenByIdAsync(int id)
        {
            var phanQuyen = await _context.PhanQuyens.FindAsync(id);
            if (phanQuyen == null) return null;

            return new PhanQuyen
            {
                MaPQ = phanQuyen.MaPQ,
                MaNV = phanQuyen.MaNV,
                MaTrang = phanQuyen.MaTrang,
                Them = phanQuyen.Them,
                Sua = phanQuyen.Sua,
                Xoa = phanQuyen.Xoa,
                Xem = phanQuyen.Xem
            };
        }

        public async Task CreatePhanQuyenAsync(PhanQuyen phanQuyenDto)
        {
            var phanQuyen = new PhanQuyen
            {
                MaNV = phanQuyenDto.MaNV,
                MaTrang = phanQuyenDto.MaTrang,
                Them = phanQuyenDto.Them,
                Sua = phanQuyenDto.Sua,
                Xoa = phanQuyenDto.Xoa,
                Xem = phanQuyenDto.Xem
            };
            _context.PhanQuyens.Add(phanQuyen);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePhanQuyenAsync(PhanQuyen phanQuyenDto)
        {
            var phanQuyen = await _context.PhanQuyens.FindAsync(phanQuyenDto.MaPQ);
            if (phanQuyen != null)
            {
                phanQuyen.MaNV = phanQuyenDto.MaNV;
                phanQuyen.MaTrang = phanQuyenDto.MaTrang;
                phanQuyen.Them = phanQuyenDto.Them;
                phanQuyen.Sua = phanQuyenDto.Sua;
                phanQuyen.Xoa = phanQuyenDto.Xoa;
                phanQuyen.Xem = phanQuyenDto.Xem;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePhanQuyenAsync(int id)
        {
            var phanQuyen = await _context.PhanQuyens.FindAsync(id);
            if (phanQuyen != null)
            {
                _context.PhanQuyens.Remove(phanQuyen);
                await _context.SaveChangesAsync();
            }
        }

        Task<IEnumerable<PhanQuyen>> IPhanQuyenService.GetAllPhanQuyenAsync()
        {
            throw new NotImplementedException();
        }

        Task<PhanQuyen> IPhanQuyenService.GetPhanQuyenByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task Create(PhanQuyen PhanQuyen)
        {
            throw new NotImplementedException();
        }

        public Task Update(PhanQuyen PhanQuyen)
        {
            throw new NotImplementedException();
        }
    }

}
