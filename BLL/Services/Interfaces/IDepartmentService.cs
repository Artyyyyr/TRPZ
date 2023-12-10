using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    internal interface IDepartmentService
    {
        IEnumerable<DepartmentDTO> GetDepartments(int page);
    }
}
