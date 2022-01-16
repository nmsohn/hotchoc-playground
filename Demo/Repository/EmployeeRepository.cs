using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Demo.Employee
{
    public class EmployeeRepository
    {
        private readonly DemoDbContext _demoDbContext;

        public EmployeeRepository(DemoDbContext demoDbContext)
        {
            _demoDbContext = demoDbContext;
        }
        
        public List<Model.Employee> GetEmployees()
        {
            return _demoDbContext.Employee.ToList();
        }

        public Model.Employee GetEmployeeById(int id)
        {
            var employee = _demoDbContext.Employee
                .Include(e => e.Department)
                .FirstOrDefault(e => e.EmployeeId == id);

            if (employee != null)
                return employee;

            return null;
        }

        public List<Model.Employee> GetEmployeesWithDepartment()
        {
            return _demoDbContext.Employee
                .Include(e => e.Department)
                .ToList();
        }

        public async Task<Model.Employee> CreateEmployee(Model.Employee employee)
        {
            await _demoDbContext.Employee.AddAsync(employee);
            await _demoDbContext.SaveChangesAsync();
            return employee;
        }
    }
}