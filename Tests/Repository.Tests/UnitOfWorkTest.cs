using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Repository.Tests
{
    [TestClass]
    public class UnitOfWorkTest
    {
        [TestMethod]
        public void ContagemTodosUsuarios()
        {
            IUnitOfWork _uow = new UnitOfWork(new DbBKContext());

            var listCount = _uow.UsuarioRepository.ListAll().Count();

            Assert.AreEqual(2, listCount);

        }

        /*public void ListarTodosUsuarios()
        {
            IUnitOfWork _uow = new UnitOfWork();
            

        }*/
    }
}
