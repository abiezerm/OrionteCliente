namespace DataLayer.ViewModels.Responses.Clients
{
    public class ClientAddressResponse
    {
        public int Id{get;set;}
        public string Address { get; set; } = null!;
        public string AddressComplemnt { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
    }
}