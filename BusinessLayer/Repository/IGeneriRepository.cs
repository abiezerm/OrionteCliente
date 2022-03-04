using DataLayer.DBModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public interface IGenericRepository<TModel, TRequestViewModel, TResponseViewModel>
        where TModel : CoreModel
        where TRequestViewModel : class
        where TResponseViewModel : class
    {
        Task<TResponseViewModel> AddAsync(TRequestViewModel input);
        Task DeleteAsync(int id);
        Task<TResponseViewModel> UpdateAsync(TRequestViewModel input);
        Task<TModel> GetByIdAsync(int id);
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<bool> AnyAsync(Expression<Func<TModel, bool>> query = null!);
        Task<bool> Exists(int id);
    }
}
