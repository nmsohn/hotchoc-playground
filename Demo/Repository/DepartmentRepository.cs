using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repository
{
    public abstract class DepartmentRepository
    {
        private readonly DemoDbContext _demoDbContext;

        protected DepartmentRepository(DemoDbContext demoDbContext)
        {
            _demoDbContext = demoDbContext;
        }
        
        public List<Model.Department> GetAllDepartmentOnly()
        {
            return _demoDbContext.Department.ToList();
        }

        public List<Model.Department> GetAllDepartmentsWithEmployee()
        {
            return _demoDbContext.Department
                .Include(d => d.Employees)
                .ToList();
        }

        public async Task<Model.Department> CreateDepartment(Model.Department department)
        {
            await _demoDbContext.Department.AddAsync(department);
            await _demoDbContext.SaveChangesAsync();
            return department;
        }
    }
}