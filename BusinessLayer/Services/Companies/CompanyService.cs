using AutoMapper;
using BusinessLayer.Repository;
using BusinessLayer.Services.Users;
using DataLayer.ViewModels.Requests.Companies;
using DataLayer.ViewModels.Responses.Companies;
using DataLayer.DBModels.Companies;
using DataLayer.ViewModels.Requests.Users;
using DataLayer.DBModels.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services.Companies
{
    
public class CompanyService : GenericRepository<Company, CompanyRequest, CompanyResponse>, ICompanyService
{
    private readonly IUserService _userService;
    private new readonly ContextDB _context;

    public CompanyService(ContextDB context, IMapper mapper, ICurrentSession currentSession,
        IUserService userService)
    : base(context, mapper, currentSession)
    {
        _context = context;
        _userService = userService;
    }

    public override async Task ValidateAsync(Company model)
    {
        var nameExists = await _entities.AnyAsync(e => e.Id != model.Id && e.Name == model.Name);
        if (nameExists)
        {
            throw new ValidationException("The company name is not avaliable");
        }
    }

    public new async Task<CompanyResponse?> AddAsync(CompanyRequest request)
    {

        var addedCompany = await base.AddAsync(request);

        // default user
        await _userService.AddAsync(new UserRequest{

            Name = "Alam",
            Email = "Amenabeato2@gmail.com",
            Password = "Alam2701",
            UserName = "Alam",
            CompanyId = addedCompany.Id
        });
        
       return addedCompany;
    }
  }
}