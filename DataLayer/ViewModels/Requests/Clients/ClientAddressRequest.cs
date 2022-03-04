using DataLayer.ViewModels.Core;

namespace DataLayer.ViewModels.Requests.Clients
{
    public class ClientAddressRequest : Request
    {
        public string Address { get; set; } = null!;
        public string AddressComplemnt { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
    }
}