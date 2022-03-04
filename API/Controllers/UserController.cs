using AutoMapper;
using BusinessLayer.Services.Users;
using DataLayer.DBModels;
using DataLayer.ViewModels;
using DataLayer.ViewModels.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DataLayer.ViewModels.Requests.Users;
using DataLayer.ViewModels.Responses.Users;
using System.Text;

namespace API.Controllers
{
    public class UserController : CoreController<IUserService, User, UserRequest, UserResponse>
    {
        public UserController(IUserService service, IMapper mapper)
            : base(service, mapper)
        {
        }

        [AllowAnonymous]
        [HttpPost("GetToken")]
        public async Task<IActionResult> GetToken()
        {
            HttpClient client = new();
            var test = new { email = "amenabeato2@gmail.com", password = "Alam2701", returnSecureToken = true };
            var usuario = JsonConvert.SerializeObject(test);
            var Url = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyBbVNEvqsH1qjhnmpLMMzPRRb8aDHVnhT0";
            var data = new StringContent(usuario, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(Url, data);

            var result = response.Content.ReadAsStringAsync().Result;

            return Ok(result);
        }
    }
}
