using AutoMapper;
using BusinessLayer.Repository;
using BusinessLayer.Services.Users;
using DataLayer.DBModels;
using DataLayer.DBModels.DBContexts;
using DataLayer.ViewModels.Requests.Clients;
using DataLayer.ViewModels.Responses.Clients;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Clients
{
    public class ClientService : GenericRepository<Client, ClientRequest, ClientResponse>, IClientService
    {
        public ClientService(ContextDB context, IMapper mapper, ICurrentSession currentSession)
        : base(context, mapper, currentSession)
        {
        }

        public override async Task ValidateAsync(Client model)
        {
            var noIdentificationExists = await _entities.AnyAsync(e => e.NoIdentification == model.NoIdentification && e.Id != model.Id);
            if (noIdentificationExists)
            {
                throw new ValidationException("Identification number is not avaliable");
            }
        }
    }
}
