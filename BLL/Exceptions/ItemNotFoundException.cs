using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeCS.BLL.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string message) : base(message)
        {
        }
    }
}
