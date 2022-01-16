using System.Threading.Tasks;
using Demo.Employee;
using HotChocolate;

namespace Demo.Mutation
{
    public class EmployeeMutation
    {
        public async Task<Model.Employee> CreateEmployeeWithDepartment([Service] EmployeeRepository employeeRepository,
            string name, int age, string email, string departmentName)
        {
            Model.Employee newEmployee = new Model.Employee
            {
                Name = name,
                Age = age,
                Email = email,
                Department = new Model.Department {Name = departmentName}
            };

            var createdEmployee = await employeeRepository.CreateEmployee(newEmployee);
            return createdEmployee;
        }

        public async Task<Model.Employee> CreateEmployeeWithDepartmentId(
            [Service] EmployeeRepository employeeRepository,
            string name, int age, string email, int departmentId)
        {
            Model.Employee newEmployee = new Model.Employee
            {
                Name = name,
                Age = age,
                Email = email,
                DepartmentId = departmentId
            };

            var createdEmployee = await employeeRepository.CreateEmployee(newEmployee);
            return createdEmployee;
        }
    }
}