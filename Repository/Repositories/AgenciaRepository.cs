using System.Data.Entity;
using Domain.Entities;
using Repository.Base;
using Repository.Interfaces.Repositories;

namespace Repository.Repositories
{
    public class AgenciaRepository : Repository<Agencia>, IAgenciaRepository
    {
        public AgenciaRepository(DbBKContext dbContext)
            : base(dbContext)
        {
        }
    }
}
