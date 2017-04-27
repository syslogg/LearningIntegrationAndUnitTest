using System.Data.Entity;
using Domain.Entities;
using Repository.Base;
using Repository.Interfaces.Repositories;

namespace Repository.Repositories
{
    public class BancoRepository : Repository<Banco> , IBancoRepository
    {
        public BancoRepository(DbBKContext dbContext)
            : base(dbContext)
        {
        }
    }
}
