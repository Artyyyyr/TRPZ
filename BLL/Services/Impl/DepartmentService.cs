using AutoMapper;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{

    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;
        private int pageNumber = 0;


        public DepartmentService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        public IEnumerable<DepartmentDTO> GetDepartments(int page)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Admin))
            {
                throw new MethodAccessException();
            }
            var departmentId = user.DepartmentId;
            var departmentsEntities = _database.Departments
                .Find(z => z.DepartmentId == departmentId, pageNumber, pageSize);

            var mapper = new MapperConfiguration(
            cfg => cfg.CreateMap<Department, DepartmentDTO>()
            ).CreateMapper();
            var departmentDto = mapper
            .Map<IEnumerable<Department>, List<DepartmentDTO>>(
            departmentsEntities);
            return departmentDto;
        }
    }
}
