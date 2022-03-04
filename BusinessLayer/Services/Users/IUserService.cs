using BusinessLayer.Repository;
using DataLayer.DBModels;
using DataLayer.ViewModels.Requests.Users;
using DataLayer.ViewModels.Responses.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Users
{
    public interface IUserService : IGenericRepository<User, UserRequest, UserResponse>
    {
        Task<User?> GetByIdAsync(string id);
    }
}
