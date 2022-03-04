using DataLayer.ViewModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModels.Requests.Clients
{
    public class ClientRequest : Request
    {
        public string Name { get; set; } = null!;
        public string NoIdentification { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public List<ClientAddressRequest> Addresses { get; set; }

    }
}
