using FirebaseAdmin.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Users
{
    public class FirebaseManager : IFirebaseManager
    {
        private readonly IFirebaseInit _firebaseInit;
        public FirebaseManager(IFirebaseInit firebaseInit)
        {
            _firebaseInit = firebaseInit;
        }
        public async Task<UserRecord> CreateUserAsync(string correo, string contraseña, string? userId = null)
        {
            try
            {
                var result = await _firebaseInit.Auth.CreateUserAsync(new UserRecordArgs()
                {
                    Uid = userId,
                    Email = correo,
                    Password = contraseña,
                });

                return result;
            }
            catch (FirebaseAuthException ex)
            {
                var message = ex.AuthErrorCode == AuthErrorCode.EmailAlreadyExists
                    ? "El correo no esta disponible"
                    : "Ha ocurrido un error";

                throw new ValidationException(message);
            }
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            try
            {
                await _firebaseInit.Auth.DeleteUserAsync(userId);

                return true;
            }
            catch (FirebaseAuthException ex)
            {
                throw new ValidationException(ex.Message);
            }
        }

        public async Task<bool> UpdateMailAsync(string userId, string correo)
        {
            try
            {
                var result = await _firebaseInit.Auth.UpdateUserAsync(new UserRecordArgs()
                {
                    Uid = userId,
                    Email = correo,
                });

                return true;
            }
            catch (FirebaseAuthException ex)
            {
                var message = ex.AuthErrorCode == AuthErrorCode.EmailAlreadyExists
                   ? "El correo no esta disponible"
                   : "Ha ocurrido un error";

                throw new ValidationException(message);
            }
        }

        public async static Task<string> Log()
        {

            HttpClient client = new();
            var test = new { email = "AlamTest@gmail.com", password = "Alam270111", returnSecureToken = true };
            var usuario = JsonConvert.SerializeObject(test);
            var Url = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyANIhnkV-zKPrEpHoR_zWC3DOWvpDfYmEs";
            var data = new StringContent(usuario, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(Url, data);

            var result = response.Content.ReadAsStringAsync().Result;

            return result;

        }
    }
}
