using Repository.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUnitOfWork : IDisposable
    {

        IBancoRepository BancoRepository { get; }
        IAgenciaRepository AgenciaRepository { get; }
        IPoupancaRepository PoupancaRepository { get; }
        ICorrenteRepository CorrenteRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }

        void Commit();
        Task CommitAsync();

    }
}