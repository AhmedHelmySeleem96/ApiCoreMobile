using ApiCoreMobile.Data;

namespace ApiCoreMobile.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IgenricRepository<Category> Catrgories { get; }
        IgenricRepository<Mobiles> Mobile { get; }
     
        Task Save();
    }
}
