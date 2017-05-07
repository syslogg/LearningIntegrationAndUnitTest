using Domain.Entities.Base;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Repository.Tests
{
    public static class HelperTests
    {
        public static Mock<DbSet<TEntity>> CreateDbSetByList<TEntity>(ref List<TEntity> data) where TEntity : Entity
        {
            var queryable = data.AsQueryable();
            var mockSet = new Mock<DbSet<TEntity>>();
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            mockSet.Setup(m => m.Add(It.IsAny<TEntity>())).Callback<TEntity>((x) =>
            {
                var list = queryable.ToList();
                list.Add(x);
                queryable = list.AsQueryable();
            });
            mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns((object[] id) => queryable.FirstOrDefault(x => x.Id == (int)id.FirstOrDefault()));
            mockSet.Setup(m => m.Remove(It.IsAny<TEntity>())).Callback<TEntity>((x) => { queryable = queryable.Where(z => z.Id != z.Id); });

            data = queryable.ToList();

            return mockSet;
        }
    }
}
