using DataLayer.ViewModels.Core;

namespace DataLayer.ViewModels.Responses.Companies
{
    
    public class CompanyResponse : Response
    {
        public string Name { get; set; }   
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string LogoUrl { get; set; } = null!;
    }
}
