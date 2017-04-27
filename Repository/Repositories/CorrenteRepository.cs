using Domain.Entities;
using Repository.Base;
using Repository.Interfaces.Repositories;
using System.Data.Entity;

namespace Repository.Repositories
{
    public class CorrenteRepository : Repository<Corrente>, ICorrenteRepository
    {
        public CorrenteRepository(DbBKContext dbContext)
            : base(dbContext)
        {
        }
    }
}
