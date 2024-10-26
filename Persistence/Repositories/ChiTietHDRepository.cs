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
    public class ChiTietHDRepository : IChiTietHDService
    {
        private readonly Hshop2023Context _context;

        public ChiTietHDRepository(Hshop2023Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChiTietHD>> GetAllChiTietHDAsync()
        {
            return await _context.ChiTietHDs
                .Select(c => new ChiTietHD
                {
                    MaCT = c.MaCT,
                    MaHD = c.MaHD,
                    MaHH = c.MaHH,
                    DonGia = c.DonGia,
                    SoLuong = c.SoLuong,
                    GiamGia = c.GiamGia
                })
                .ToListAsync();
        }

        public async Task<ChiTietHD> GetChiTietHDByIdAsync(int id)
        {
            var chiTietHD = await _context.ChiTietHDs.FindAsync(id);
            if (chiTietHD == null) return null;

            return new ChiTietHD
            {
                MaCT = chiTietHD.MaCT,
                MaHD = chiTietHD.MaHD,
                MaHH = chiTietHD.MaHH,
                DonGia = chiTietHD.DonGia,
                SoLuong = chiTietHD.SoLuong,
                GiamGia = chiTietHD.GiamGia
            };
        }

        public async Task CreateChiTietHDAsync(ChiTietHD chiTietHDDto)
        {
            var chiTietHD = new ChiTietHD
            {
                MaHD = chiTietHDDto.MaHD,
                MaHH = chiTietHDDto.MaHH,
                DonGia = chiTietHDDto.DonGia,
                SoLuong = chiTietHDDto.SoLuong,
                GiamGia = chiTietHDDto.GiamGia
            };
            _context.ChiTietHDs.Add(chiTietHD);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateChiTietHDAsync(ChiTietHD chiTietHDDto)
        {
            var chiTietHD = await _context.ChiTietHDs.FindAsync(chiTietHDDto.MaCT);
            if (chiTietHD != null)
            {
                chiTietHD.MaHD = chiTietHDDto.MaHD;
                chiTietHD.MaHH = chiTietHDDto.MaHH;
                chiTietHD.DonGia = chiTietHDDto.DonGia;
                chiTietHD.SoLuong = chiTietHDDto.SoLuong;
                chiTietHD.GiamGia = chiTietHDDto.GiamGia;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteChiTietHDAsync(int id)
        {
            var chiTietHD = await _context.ChiTietHDs.FindAsync(id);
            if (chiTietHD != null)
            {
                _context.ChiTietHDs.Remove(chiTietHD);
                await _context.SaveChangesAsync();
            }
        }

        Task<ChiTietHD> IChiTietHDService.GetChiTietHDByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task Create(ChiTietHD ChiTietHD)
        {
            throw new NotImplementedException();
        }

        public Task Update(ChiTietHD ChiTietHD)
        {
            throw new NotImplementedException();
        }
    }

}
