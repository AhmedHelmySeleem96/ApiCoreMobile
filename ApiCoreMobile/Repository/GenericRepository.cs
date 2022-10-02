using ApiCoreMobile.Data;
using ApiCoreMobile.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace ApiCoreMobile.Repository
{
    public class GenericRepository<T> :IgenricRepository<T> where T : class
    {
        private readonly MobileContext _Context;

        private readonly DbSet<T> _db;
        public GenericRepository(MobileContext context)
        {
            _Context = context;
            _db = _Context.Set<T>();
        }

        public async Task Delete(int Id)
        {
            var entity = await _db.FindAsync(Id);
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entites)
        {
            _db.RemoveRange(entites);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> include = null)
        {
            IQueryable<T> Query = _db;

            if(include != null)
            {
                foreach (var IncludeProperity in include)
                {
                    Query = Query.Include(IncludeProperity);
                }
            }
            return await Query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> include = null)
        {
            IQueryable<T> Query = _db;
            if(expression != null)
            {
                Query = Query.Where(expression);
            }
            if (include != null)
            {
                foreach (var IncludeProperity in include)
                {
                    Query = Query.Include(IncludeProperity);
                }
            }
            if(orderBy != null)
            {
                Query = orderBy(Query);
            }
            return await Query.AsNoTracking().ToListAsync();
        }

        public async Task insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async void InsertRange(IEnumerable<T> entites)
        {
            await _db.AddRangeAsync(entites);
        }

        public void update(T entity)
        {
            _db.Attach(entity);
            _Context.Entry(entity).State= EntityState.Modified;
        }
    }
}
