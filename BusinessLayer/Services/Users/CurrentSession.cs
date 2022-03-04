using DataLayer.DBModels;
using DataLayer.DBModels.DBContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Users
{
    public class CurrentSession : ICurrentSession
    {
        // private readonly IUserService _userService;
        private readonly ContextDB _context;
        private readonly IHttpContextAccessor _httpContextAccessor = null!;

        public CurrentSession(ContextDB context,IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<User> GetCurrentUser()
        {
            var id = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            Console.WriteLine($"{id}");

            var user = await _context.Users.FirstOrDefaultAsync(u=>u.FirebaseId == id);
            if (user is null)
            {
                throw new UnauthorizeException("No se ha encontrado el usuario");
            }
            return user;
        }
    }
}
