using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using BusinessLayer.Services.Companies;
using DataLayer.DBModels;
using DataLayer.ViewModels.Requests.Companies;
using DataLayer.ViewModels.Responses.Companies;
using Microsoft.AspNetCore.Authorization;
using DataLayer.DBModels.Companies;

namespace API.Controllers
{
    public class CompanyController : CoreController<ICompanyService,Company,CompanyRequest,CompanyResponse>
    {
        public CompanyController(ICompanyService service,IMapper mapper)
            : base (service, mapper){

            }
        
    }
}