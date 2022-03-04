using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Users
{
    public class FirebaseInit : IFirebaseInit
    {

        private readonly IHostingEnvironment _enviroment = null!;
        public FirebaseAuth Auth { get; set; } = null!;

        public FirebaseInit(IHostingEnvironment enviroment)
        {
            _enviroment = enviroment;
            Init();
        }

        public void Init()
        {
            var defaultApp = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(Path.Combine(_enviroment.WebRootPath, "oriontek-482c8-firebase-adminsdk-joc41-ad4fbcc816.json")),
            });

            Auth = FirebaseAuth.GetAuth(defaultApp);
        }
    }
}
