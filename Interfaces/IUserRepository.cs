using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Interfaces
{
    interface IUserRepository
    {
        Task<User> findUserByEmailAndPassword(string email, string password);
    }
}
