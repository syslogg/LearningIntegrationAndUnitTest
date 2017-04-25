using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace Repository.Tests
{
    [TestClass]
    public class UnitOfWorkTest
    {
        [TestMethod]
        public void ContagemTodosUsuarios()
        {
            var mock = new Mock<DbBKContext>();
            var uow = new UnitOfWork(mock.Object);

        }

        /*public void ListarTodosUsuarios()
        {
            IUnitOfWork _uow = new UnitOfWork();
            

        }*/
    }
}
