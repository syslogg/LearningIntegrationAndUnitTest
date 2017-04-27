using Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Repository.Tests.Base
{
    public class BaseDataTest
    {

        protected Mock<DbBKContext> _mockDbContext;
        protected Mock<DbSet<Usuario>> _mockDbSet;
        protected List<Usuario> _listUsuario;
        protected IUnitOfWork _uow;

        public virtual void Initialize()
        {
            //Lista do mock;
            _listUsuario = new List<Usuario>()
            {
                new Usuario(){Id = 1, Nome = "Nome - 1", Endereco = "Endereco - 1" },
                new Usuario(){Id = 2, Nome = "Nome - 2", Endereco = "Endereco - 2" },
                new Usuario(){Id = 3, Nome = "Nome - 3", Endereco = "Endereco - 3" }
            };

            //Instancias
            _mockDbSet = new Mock<DbSet<Usuario>>();
            _mockDbContext = new Mock<DbBKContext>();

            //Setup DbSet
            _mockDbSet = HelperTests.CreateDbSetByList<Usuario>(_listUsuario);
            //_mockDbSet = HelperTests.CreateDbSetByList<Usuario>(_listMockUsuario);

            //Setup DbContext
            _mockDbContext.Setup(x => x.Set<Usuario>()).Returns(_mockDbSet.Object);

            //Instancia do UOW
            _uow = new UnitOfWork(_mockDbContext.Object);
        }
    }
}
