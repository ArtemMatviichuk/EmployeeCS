using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCS.BLL.Exceptions
{
    public class ContractException : Exception
    {
        public ContractException(string message) : base(message)
        {
        }
    }
}
