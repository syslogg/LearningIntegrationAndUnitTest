using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Repository.Tests
{
    [TestClass]
    public class UnitOfWorkTest
    {

        private Mock<IUnitOfWork> _mockUOW;
        private Mock<DbBKContext> _mockDbContext;
        private List<Usuario> _expected;
        private List<Usuario> _listTest;

        [TestInitialize]
        public void Initialize()
        {
            _mockUOW = new Mock<IUnitOfWork>();
            _mockDbContext = new Mock<DbBKContext>();
            _mockDbContext.Setup(x => x.Set<Usuario>()).Returns(Mock.Of<DbSet<Usuario>>());
            var uow = new UnitOfWork(_mockDbContext.Object);
            _expected = new List<Usuario>()
            {
                new Usuario() {Id = 1, Endereco = "Rua 1", Nome = "Nome1" },
                new Usuario() {Id = 2, Endereco = "Rua 2", Nome = "Nome2" },
                new Usuario() {Id = 3, Endereco = "Rua 3", Nome = "Nome3" }
            };
            _listTest = new List<Usuario>()
            {
                new Usuario() {Id = 1, Endereco = "Rua 1", Nome = "Nome1" },
                new Usuario() {Id = 2, Endereco = "Rua 2", Nome = "Nome2" },
                new Usuario() {Id = 3, Endereco = "Rua 3", Nome = "Nome3" }
            };

        }

        [TestMethod]
        public void GetTodosUsuarios()
        {
            //Arrange
            _mockUOW.Setup(x => x.UsuarioRepository.ListAll()).Returns(_listTest);

            //Act
            var result = _mockUOW.Object.UsuarioRepository.ListAll();

            //Assert
            Assert.AreEqual(_expected[0].Nome, result.ToArray()[0].Nome);
        }

        /*public void ListarTodosUsuarios()
        {
            IUnitOfWork _uow = new UnitOfWork();
            

        }*/
    }
}
