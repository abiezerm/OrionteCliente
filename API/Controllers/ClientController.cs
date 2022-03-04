using AutoMapper;
using BusinessLayer.Services.Clients;
using DataLayer.DBModels;
using DataLayer.ViewModels.Requests.Clients;
using DataLayer.ViewModels.Responses.Clients;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class ClientController : CoreController<IClientService, Client, ClientRequest, ClientResponse>
    {
        public ClientController(IClientService service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}
