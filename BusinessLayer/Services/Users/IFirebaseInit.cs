using FirebaseAdmin.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Users
{
    public interface IFirebaseInit
    {
        public FirebaseAuth Auth { get; set; }
    }
}
