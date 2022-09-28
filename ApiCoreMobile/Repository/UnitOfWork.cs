using ApiCoreMobile.Data;
using ApiCoreMobile.IRepository;

namespace ApiCoreMobile.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MobileContext _context;
        private IgenricRepository<Category> _category;
        private IgenricRepository<Mobiles> _mobile;

        public UnitOfWork(MobileContext context)
        {
            _context = context;
        }

        public IgenricRepository<Category> Catrgories => new GenericRepository<Category>(_context);

        public IgenricRepository<Mobiles> Mobile => new GenericRepository<Mobiles>(_context);

        public void Dispose()
        {
            _context.Dispose(); 
            GC.SuppressFinalize(this);
        }

      

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
