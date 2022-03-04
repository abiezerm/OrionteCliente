using System.Linq.Expressions;
using AutoMapper;
using DataLayer.DBModels;
using DataLayer.DBModels.Core;
using DataLayer.DBModels.DBContexts;
using DataLayer.ViewModels.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Services.Users;

namespace BusinessLayer.Repository
{
    public class GenericRepository<TModel, TRequestViewModel, TResponseViewModel>
        : IGenericRepository<TModel, TRequestViewModel, TResponseViewModel>
        where TModel : CoreModel
        where TRequestViewModel : Request
        where TResponseViewModel : class
    {
        internal IMapper _mapper;
        internal ContextDB _context;
        internal DbSet<TModel> _entities;
        internal ICurrentSession _currentSession;

        public GenericRepository(ContextDB context, IMapper mapper, ICurrentSession currentSession)
        {
            _mapper = mapper;
            _context = context;
            _entities = context.Set<TModel>();
            _currentSession = currentSession;
        }

        public virtual async Task ValidateAsync(TModel model)
        {
            await Task.CompletedTask;
        }
        public async Task<bool> AnyAsync(Expression<Func<TModel, bool>> query = null!)
        {
            return await _entities.AnyAsync(query);
        }
        public async Task<TResponseViewModel> AddAsync(TRequestViewModel input)
        {
            var model = _mapper.Map<TModel>(input);
            var currentUser = await _currentSession.GetCurrentUser();

            await ValidateAsync(model);

            var companyProperty = model.GetType().GetProperties().FirstOrDefault(d => d.Name == "CompanyId");
            if (companyProperty is not null)
            {
                companyProperty.SetValue(model, currentUser.CompanyId);
            }

            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            return _mapper.Map<TModel, TResponseViewModel>(model);
        }
        public async Task<bool> Exists(int id)
        {
            return await _entities.AnyAsync(e => e.Id == id);
        }
        public async Task<bool> Exists(string id)
        {
            return await _entities.AnyAsync(e => e.Id.ToString() == id);
        }
        public async Task DeleteAsync(int id)
        {
            var model = await _entities.FindAsync(id);
            if (model is null)
            {
                throw new NotFoundException($"No se ha encontrado la entidad {typeof(TModel).Name}");
            }
            model.Status = false;
            await _context.SaveChangesAsync();
        }
        public async Task<TResponseViewModel> UpdateAsync(TRequestViewModel input)
        {
            var model = await _context.Set<TModel>().FindAsync(input.Id);

            if (model is null)
            {
                throw new ValidationException("not found");
            }

            _mapper.Map(input, model);

            await ValidateAsync(model);

            await _context.SaveChangesAsync();

            return _mapper.Map<TModel, TResponseViewModel>(model);

        }
        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var list = await _entities.ToListAsync();
            return list;
        }
        public async Task<TModel> GetByIdAsync(int id)
        {
            var model = await _entities.FindAsync(id);
            if (model is null)
            {
                throw new NotFoundException($"No se ha encontrado la entidad {typeof(TModel).Name}");
            }

            return model;
        }

    }
}
