using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task Add(User user);
        Task Update(User user);
        Task Delete(int id);
        Task<User> AuthenticateUser(string email, string matKhau);
        Task<User?> GetUserByEmail(string email);
        Task UpdatePassword(User user, string newPassword);
        Task SendOtpToEmail(string email, string otp);
    }
}