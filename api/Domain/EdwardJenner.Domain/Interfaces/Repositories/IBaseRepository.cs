using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EdwardJenner.Models.Interfaces.Models;

namespace EdwardJenner.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TModel> where TModel : IModelBase
    {
        Task Insert(TModel entity);
        Task<TModel> FindBy(Expression<Func<TModel, bool>> filter);
        Task<IList<TModel>> ListBy(Expression<Func<TModel, bool>> filter);
        Task<TModel> Update(TModel entity);
        Task Delete(Expression<Func<TModel, bool>> filter);
        Task<TModel> Save(TModel entity);
    }
}
