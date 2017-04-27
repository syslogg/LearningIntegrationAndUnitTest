using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repository.Base;
using Repository.Interfaces.Repositories;
using Repository.Repositories;
using Repository.Tests.Base;
using System.Collections.Generic;
using System.Data.Entity;
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
        public void GetAllUser()
        {
            var result = _uow.UsuarioRepository.ListAll();

            Assert.AreEqual(_listUsuario.Count(), result.Count());
            
        }

        [TestMethod]
        public void GetUserByPredicate()
        {
            //Act
            var result = _uow.UsuarioRepository.Find(x => x.Id == 1);
            
            //Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count());
            Assert.AreEqual(_listUsuario.FirstOrDefault(x => x.Id == 1).Nome, result.FirstOrDefault().Nome);
            Assert.AreEqual(_listUsuario.FirstOrDefault(x => x.Id == 1).Endereco, result.FirstOrDefault().Endereco);

        }

        
        

    }
}
