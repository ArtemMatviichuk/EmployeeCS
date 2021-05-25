using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeCS.BLL.Interfaces;
using EmployeeCS.BLL.Exceptions;
using EmployeeCS.DTO.Employee;
using BLL.DTO.Employee;

namespace EmployeeCS.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService service)
        {
            employeeService = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeShort>> GetAll()
        {
            try
            {
                return Ok(employeeService.GetAllEmployeesShort());
            }
            catch (RepositoryException ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("detailed")]
        public ActionResult<IEnumerable<EmployeeDto>> GetAllDetailed()
        {
            try
            {
                return Ok(employeeService.GetAllEmployees());
            }
            catch (RepositoryException ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetById(int id)
        {
            try
            {
                return Ok(await employeeService.GetEmployee(id));
            }
            catch (ItemNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> CreateEmployee(NewEmployeeData data)
        {
            try
            {
                return Accepted(await employeeService.CreateEmployee(data));
            }
            catch (ContractException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (RepositoryException ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeDto>> DeleteEmployee(int id)
        {
            try
            {
                await employeeService.DeleteEmployee(id);
                return NoContent();
            }
            catch (RepositoryException ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee(EmployeeDto employeeDto)
        {
            try
            {
                return Accepted(await employeeService.UpdateEmployee(employeeDto));
            }
            catch (RepositoryException ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
