using DataLayer.ViewModels.Responses.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModels.Responses.Users
{
    public class UserResponse : ViewModelResponse
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
    }
}
