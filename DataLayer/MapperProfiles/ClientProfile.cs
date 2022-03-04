using AutoMapper;
using DataLayer.DBModels;
using DataLayer.ViewModels.Requests.Clients;
using DataLayer.ViewModels.Responses.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.MapperProfiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientRequest, Client>();
            CreateMap<Client, ClientResponse>();
            CreateMap<ClientAddressRequest, ClientAddress>();
            CreateMap<ClientAddress,ClientAddressResponse>();

        }
    }
}
