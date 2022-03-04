using AutoMapper;
using BusinessLayer.Repository;
using DataLayer.DBModels;
using DataLayer.DBModels.DBContexts;
using DataLayer.ViewModels.Requests.Users;
using DataLayer.ViewModels.Responses.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Users
{
    public class UserService : GenericRepository<User, UserRequest, UserResponse>, IUserService
    {
        private readonly IFirebaseManager _firebaseManager;

        public UserService(ContextDB context, IMapper mapper, IFirebaseManager firebaseManager, ICurrentSession currentSession)
            : base(context, mapper, currentSession)
        {
            _firebaseManager = firebaseManager;
        }

        public async new Task ValidateAsync(User model)
        {
            var usernameExists = await _entities.AnyAsync(u => u.UserName == model.UserName && u.Id == model.Id);
            if (usernameExists)
            {
                throw new ValidationException("The username is not avaliable");
            }
        }

        public new async Task<UserResponse> AddAsync(UserRequest input)
        {
            var firebaseUser = await _firebaseManager.CreateUserAsync(input.Email, input.Password);
            try
            {
                var model = _mapper.Map<UserRequest, User>(input);
                model.FirebaseId = firebaseUser.Uid;

                await ValidateAsync(model);

                await _context.AddAsync(model);
                await _context.SaveChangesAsync();

                return _mapper.Map<User, UserResponse>(model);
            }
            catch (Exception)
            {
                await _firebaseManager.DeleteUserAsync(firebaseUser.Uid);
                throw;
            }
        }
        public async Task<User?> GetByIdAsync(string id)
        {
            return await _entities.FirstOrDefaultAsync(u => u.FirebaseId == id);
        }
    }
}
