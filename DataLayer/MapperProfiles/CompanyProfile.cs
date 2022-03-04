using AutoMapper;
using DataLayer.DBModels;
using DataLayer.ViewModels.Requests.Companies;
using DataLayer.ViewModels.Responses.Companies;
using DataLayer.DBModels.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.MapperProfiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyRequest, Company>();
            CreateMap<Company, CompanyResponse>();
        }
    }
}