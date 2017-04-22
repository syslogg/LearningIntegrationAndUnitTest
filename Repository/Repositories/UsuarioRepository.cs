using Domain.Entities;
using Repository.Base;
using Repository.Interfaces.Repositories;
using System.Data.Entity;

namespace Repository.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
