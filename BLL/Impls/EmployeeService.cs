using AutoMapper;
using BLL.DTO.Employee;
using EmployeeCS.BLL.Exceptions;
using EmployeeCS.BLL.Interfaces;
using EmployeeCS.DAL.Models;
using EmployeeCS.DAL.Repos.Interfaces;
using EmployeeCS.DTO.Employee;
using EmployeeCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCS.BLL.Impls
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository Repository;
        private readonly IMapper Mapper;
        public EmployeeService(IEmployeeRepository repository)
        {
            Repository = repository;

            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>()
                    .ForMember(destinationMember => destinationMember.Gender,
                        opts => opts.MapFrom(sourceMember => sourceMember.Gender.ToString()));

                cfg.CreateMap<EmployeeDto, Employee>()
                    .ForMember(destinationMember => destinationMember.Gender,
                        opts => opts.MapFrom(sourceMember => sourceMember.Gender == "Male" ? Gender.Male : Gender.Female));

                cfg.CreateMap<NewEmployeeData, Employee>()
                    .ForMember(destinationMember => destinationMember.Gender,
                        opts => opts.MapFrom(sourceMember => sourceMember.Gender ? Gender.Male : Gender.Female));

                cfg.CreateMap<Employee, EmployeeShort>()
                    .ForMember(destinationMember => destinationMember.FullName,
                        opts => opts.MapFrom(sourceMember => sourceMember.FirstName + " " + sourceMember.LastName));
            }).CreateMapper();
        }
        public async Task<EmployeeDto> CreateEmployee(NewEmployeeData data)
        {
            if (data == null)
                throw new ContractException("Data can not be null!");

            try
            {
                return Mapper.Map<EmployeeDto>(await Repository.AddAsync(Mapper.Map<Employee>(data)));
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Can not create employee", ex);
            }
        }

        public async Task DeleteEmployee(int id)
        {
            try
            {
                await Repository.RemoveAsync(await Repository.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Can not delete employee", ex);
            }
        }

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            try
            {
                return Mapper.Map<IEnumerable<EmployeeDto>>(Repository.GetAll().AsEnumerable());
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message);
            }
        }

        public IEnumerable<EmployeeShort> GetAllEmployeesShort()
        {
            try
            {
                return Mapper.Map<IEnumerable<EmployeeShort>>(Repository.GetAll().AsEnumerable());
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message);
            }
        }

        public async Task<EmployeeDto> GetEmployee(int id)
        {
            Employee employee = await Repository.GetByIdAsync(id);

            if (employee == null)
                throw new ItemNotFoundException("Employee not found!");

            return Mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> UpdateEmployee(EmployeeDto data)
        {
            if (data == null)
                throw new ContractException("Data can not be null!");

            try
            {
                return Mapper.Map<EmployeeDto>(await Repository.UpdateAsync(Mapper.Map<Employee>(data)));
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message);
            }
        }
    }
}
