using EmployeeCS.DAL.Repos.Interfaces;
using EmployeeCS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCS.DAL.Repos.Impls
{
    public class EmployeeRepository : IEmployeeRepository
    {
        protected readonly DataContext DataContext;

        public EmployeeRepository(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public IQueryable<Employee> GetAll()
        {
            try
            {
                return DataContext.Employees;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<Employee> AddAsync(Employee entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await DataContext.AddAsync(entity);
                await DataContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<Employee> UpdateAsync(Employee entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }

            try
            {
                DataContext.Update(entity);
                await DataContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        public Task<Employee> GetByIdAsync(int id)
        {
            return GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(Employee entity)
        {
            try
            {
                DataContext.Employees.Remove(entity);
                await DataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be deleted: {ex.Message}");
            }
        }
    }
}
