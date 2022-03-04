using FirebaseAdmin.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Users
{
    public interface IFirebaseManager
    {
        Task<UserRecord> CreateUserAsync(string correo, string contraseña, string? userId = null);
        Task<bool> DeleteUserAsync(string userId);
    }
}
