using System.Linq.Expressions;

namespace ApiCoreMobile.IRepository
{
    public interface IgenricRepository<T> where T : class
    {
        Task<IList<T>> GetAll(Expression<Func<T,bool>> expression = null
            ,Func<IQueryable<T>,IOrderedQueryable<T>> orderBy = null
            ,List<string> include = null );
       
        Task<T> Get(Expression<Func<T, bool>> expression,List<string> include = null);

        Task insert(T entity);

        void update(T entity);

        Task Delete(int Id);
        void InsertRange(IEnumerable<T> entites);

        void DeleteRange(IEnumerable<T> entites);
    }
}
