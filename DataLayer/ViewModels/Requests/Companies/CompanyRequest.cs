using DataLayer.ViewModels.Core;

namespace DataLayer.ViewModels.Requests.Companies
{
    public class CompanyRequest : Request
    {
    public string Name { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string LogoUrl { get; set; } = null!;
    }
}
