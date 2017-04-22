using System;
using Repository.Interfaces.Repositories;
using Repository.Repositories;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork()
        {
            CreateDbContext();
        }

        public UnitOfWork(DbBKContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbBKContext _dbContext;

        private IBancoRepository _bancoRepository = null;

        public IBancoRepository BancoRepository
        {
            get
            {
                if(_bancoRepository == null)
                {
                    _bancoRepository = new BancoRepository(_dbContext);
                }
                return _bancoRepository;
            }
        }

        private IAgenciaRepository _agenciaRepository = null;

        public IAgenciaRepository AgenciaRepository
        {
            get
            {
                if (_agenciaRepository == null)
                {
                    _agenciaRepository = new AgenciaRepository(_dbContext);
                }
                return _agenciaRepository;
            }
        }

        private IPoupancaRepository _poupancaRepository = null;

        public IPoupancaRepository PoupancaRepository
        {
            get
            {
                if (_poupancaRepository == null)
                {
                    _poupancaRepository = new PoupancaRepository(_dbContext);
                }
                return _poupancaRepository;
            }
        }

        private ICorrenteRepository _correnteRepository = null;

        public ICorrenteRepository CorrenteRepository
        {
            get
            {
                if (_correnteRepository == null)
                {
                    _correnteRepository = new CorrenteRepository(_dbContext);
                }
                return _correnteRepository;
            }
        }

        private IUsuarioRepository _usuarioRepository = null;

        public IUsuarioRepository UsuarioRepository
        {
            get
            {
                if (_usuarioRepository == null)
                {
                    _usuarioRepository = new UsuarioRepository(_dbContext);
                }
                return _usuarioRepository;
            }
        }

        private void CreateDbContext()
        {
            _dbContext = new DbBKContext();
        }

        public void Dispose()
        {
            if(_dbContext != null)
            {
                _dbContext.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
