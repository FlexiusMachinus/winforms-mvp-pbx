using Moq;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace DB_CourseWork.Tests
{
    public static class QueryableExtensions
    {
        public static Mock<DbSet<T>> GetMockDbSet<T>(this IQueryable<T> queryable) where T : class
        {
            var mock = new Mock<DbSet<T>>();
            mock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            mock.As<IQueryable>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            mock.Setup(m => m.Local).Returns(new ObservableCollection<T>(queryable));
            mock.Setup(m => m.Include(It.IsAny<string>())).Returns(mock.Object);

            return mock;
        }
    }
}
