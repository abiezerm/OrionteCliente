using BusinessLayer.Repository;
using DataLayer.DBModels;
using DataLayer.ViewModels.Requests.Clients;
using DataLayer.ViewModels.Responses.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Clients
{
    public interface IClientService : IGenericRepository<Client, ClientRequest, ClientResponse>
    {
    }
}
