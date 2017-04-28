using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repository.Tests.Base;
using System.Linq;

namespace Repository.Tests
{
    [TestClass]
    public class UnitOfWorkTest : BaseDataTest
    {
        
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestMethod]
        public void GetAllItem()
        {
            var result = _uow.UsuarioRepository.ListAll();

            Assert.AreEqual(_listUsuario.Count(), result.Count());
            
        }

        [TestMethod]
        public void GetItemByPredicate()
        {
            //Act
            var result = _uow.UsuarioRepository.Find(x => x.Id == 1);
            
            //Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count());
            Assert.AreEqual(_listUsuario.FirstOrDefault(x => x.Id == 1).Nome, result.FirstOrDefault().Nome);
            Assert.AreEqual(_listUsuario.FirstOrDefault(x => x.Id == 1).Endereco, result.FirstOrDefault().Endereco);

        }

        [TestMethod]
        public void AddItem()
        {
            //Act
            var result = _uow.UsuarioRepository.Add(new Usuario() { Nome = "Teste Add", Endereco = "Teste Add" });
            _uow.Commit();

            _mockDbSet.Verify(x => x.Add(It.IsAny<Usuario>()), Times.Once());
            _mockDbContext.Verify(x => x.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void GetItem()
        {
            //Act
            var result = _uow.UsuarioRepository.Get(1);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(_listUsuario.FirstOrDefault(x => x.Id == 1).Id, result.Id);
            Assert.AreEqual(_listUsuario.FirstOrDefault(x => x.Id == 1).Nome, result.Nome);
            Assert.AreEqual(_listUsuario.FirstOrDefault(x => x.Id == 1).Endereco, result.Endereco);
        }

        [TestMethod]
        public void DeleteItem()
        {
            //Act
            // _uow.UsuarioRepository.Delete(new Usuario() { Id = 1 });

            //Assert
            //Assert.
        }
        

    }
}
