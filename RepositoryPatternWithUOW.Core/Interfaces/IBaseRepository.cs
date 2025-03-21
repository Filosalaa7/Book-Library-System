using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RepositoryPatternWithUOW.Core.Constants;

namespace RepositoryPatternWithUOW.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);

        T Find(Expression<Func<T, bool>> criteria, string[] includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int take , int skip);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take , int? skip,
            Expression<Func<T, object>> orderBy = null, string OrderByDirection = OrderBy.Ascending);

        IEnumerable<T> AddRange(IEnumerable<T> entities);

        T Update(T entity);

        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void Attach(T entity);

        int Count();
        int Count(Expression<Func<T, bool>> criteria);
    }
}
