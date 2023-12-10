using BLL.Services.Impl;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.Repositories;
using DAL.UnitOfWork;
using Google.Protobuf.WellKnownTypes;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tests
{
    public class DepartmentServiceTests
    {

        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(
            () => new DepartmentService(nullUnitOfWork)
            );
        }

        [Fact]
        public void GetDepartments_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Customer(1, "test", 1);
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IDepartmentService streetService = new DepartmentService(mockUnitOfWork.Object);
            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => streetService.GetDepartments(0));
        }

        [Fact]
        public void GetDepartments_DepartmentFromDAL_CorrectMappingToDepartmentDTO()
        {
            // Arrange
            User user = new Admin(1, "test", 1);
            SecurityContext.SetUser(user);
            var departmentService = GetDepartmentService();
            // Act
            var actualStreetDto = departmentService.GetDepartments(0).First();
            // Assert
            Assert.True(
            actualStreetDto.DepartmentId == 1
            && actualStreetDto.Name == "testN"
            && actualStreetDto.Description == "testD"
            );
        }

        IDepartmentService GetDepartmentService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedDepartment= new Department()
            {
                DepartmentId = 1,
                Name = "testN",
                Description = "testD"
            };
            var mockDbSet = new Mock<IDepartmentRepository>();
            mockDbSet
            .Setup(z =>
            z.Find(
            It.IsAny<Func<Department, bool>>(),
            It.IsAny<int>(),
            It.IsAny<int>()))
            .Returns(
            new List<Department>() { expectedDepartment }
            );
            mockContext
            .Setup(context =>
            context.Departments)
            .Returns(mockDbSet.Object);
            IDepartmentService departmentService = new DepartmentService(mockContext.Object);
            return departmentService;
        }

    }


}
