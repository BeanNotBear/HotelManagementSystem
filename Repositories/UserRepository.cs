using HotelManagementSystem.Data;
using HotelManagementSystem.Interfaces;
using HotelManagementSystem.Models;
using HotelManagementSystem.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private HotelManagementDbContext _context;

        public UserRepository(HotelManagementDbContext context)
        {
            _context = context;
        }

        public async Task<User> findUserByEmailAndPassword(string email, string password)
        {
            Hashing hashing = new Hashing();
            password = hashing.ComputeSha256Hash(password);
            var user = await _context.Users.FirstOrDefaultAsync(u => (u.Email.ToLower().Equals(email.ToLower()) && u.Password.Equals(password)));
            return user;
        }
    }
}
