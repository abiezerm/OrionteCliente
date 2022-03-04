using BusinessLayer.Repository;
using DataLayer.ViewModels.Requests.Companies;
using DataLayer.ViewModels.Responses.Companies;
using DataLayer.DBModels.Companies;

namespace BusinessLayer.Services.Companies
{
    public interface ICompanyService : IGenericRepository<Company, CompanyRequest, CompanyResponse>
{

}
    
}
