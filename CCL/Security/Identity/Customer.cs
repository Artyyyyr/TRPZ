using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class Customer : User
    {
        public Customer(int userId, string userName, int departmentId) 
            : base(userId, userName, departmentId, nameof(Customer))
        {
        }
    }
}
