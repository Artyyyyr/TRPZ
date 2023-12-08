using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using DAL.Repositories.imp;
using DAL.Entities;
using DAL.EF;

namespace DAL.Tests
{
    class TestDepartmentRepository: BaseRepository<Department>
    {
        public TestDepartmentRepository(DbContext context): base(context)
        {
        }
    }


    public class BaseRepositoryUnitTests
    {

        [Fact]
        public void Create_inputDepartmentInstance_CalledAddMethodOfDBSetDepartmentInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<MyContext>().Options;
            var mockContext = new Mock<MyContext>(opt);
            var mockDbSet = new Mock<DbSet<Department>>();
            mockContext.Setup(context => context.Set<Department>()).Returns(mockDbSet.Object);
            var repository = new TestDepartmentRepository(mockContext.Object);
            Department expectedDepartment = new Mock<Department>().Object;
            //Act
            repository.Create(expectedDepartment);
            // Assert
            mockDbSet.Verify(dbSet => dbSet.Add(expectedDepartment), Times.Once());
            // mockDbSet.Verify(dbSet => dbSet.Add(expectedDepartment), Times.Never());
        }
        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<MyContext>().Options;
            var mockContext = new Mock<MyContext>(opt);
            var mockDbSet = new Mock<DbSet<Department>>();
            mockContext.Setup(context => context.Set<Department>()).Returns(mockDbSet.Object);
            Department expectedDepartment = new Department() { DepartmentId = 4, Description = "About engeneering", Name = "Engeneering" };
            mockDbSet.Setup(mock => mock.Find(expectedDepartment.DepartmentId)).Returns(expectedDepartment);
            var repository = new TestDepartmentRepository(mockContext.Object);
            //Act
            var actualDepartment = repository.Get(expectedDepartment.DepartmentId);
            // Assert
            mockDbSet.Verify(dbSet => dbSet.Find(expectedDepartment.DepartmentId), Times.Once());
            Assert.Equal(expectedDepartment, actualDepartment);
        }
        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<MyContext>().Options;
            var mockContext = new Mock<MyContext>(opt);
            var mockDbSet = new Mock<DbSet<Department>>();
            mockContext.Setup(context => context.Set<Department>()).Returns(mockDbSet.Object);
            var repository = new TestDepartmentRepository(mockContext.Object);
            Department expectedDepartment = new Department() { DepartmentId = 4 };
            mockDbSet.Setup(mock => mock.Find(expectedDepartment.DepartmentId)).Returns(expectedDepartment);
            //Act
            repository.Delete(expectedDepartment.DepartmentId);
            // Assert
            mockDbSet.Verify(dbSet => dbSet.Find(expectedDepartment.DepartmentId), Times.Once());
            mockDbSet.Verify(dbSet => dbSet.Remove(expectedDepartment), Times.Once());

        }
    }
}
