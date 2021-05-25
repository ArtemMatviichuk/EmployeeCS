using BLL.DTO.Employee;
using EmployeeCS.DTO.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCS.BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> CreateEmployee(NewEmployeeData data);
        Task<EmployeeDto> UpdateEmployee(EmployeeDto data);
        Task DeleteEmployee(int id);
        Task<EmployeeDto> GetEmployee(int id);
        IEnumerable<EmployeeDto> GetAllEmployees();
        IEnumerable<EmployeeShort> GetAllEmployeesShort();
    }
}
