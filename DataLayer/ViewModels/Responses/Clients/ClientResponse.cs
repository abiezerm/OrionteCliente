using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModels.Responses.Clients
{
    public class ClientResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string NoIdentification { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime? CreatedAt{get;set;}
        public bool Status{get;set;}
        public List<ClientAddressResponse> Addresses { get; set; }
    }
}
