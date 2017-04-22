using System.Data.Entity;
using Domain.Entities;
using Repository.Base;
using Repository.Interfaces.Repositories;

namespace Repository.Repositories
{
    public class PoupancaRepository : Repository<Poupanca>, IPoupancaRepository
    {
        public PoupancaRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
