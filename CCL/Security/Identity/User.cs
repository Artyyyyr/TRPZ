using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public abstract class User
    {
        public int UserId { get; }
        public string UserName { get; }
        public int DepartmentId { get; }

        protected string UserType { get; }

        public User(int userId, string userName, int departmentId, string userType)
        {
            UserId = userId;
            UserName = userName;
            DepartmentId = departmentId;
            UserType = userType;
        }
    }

}
