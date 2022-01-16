using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Employee;
using HotChocolate;
using HotChocolate.Subscriptions;

namespace Demo.Query
{
    public class EmployeeQuery
    {
        public List<Model.Employee> AllEmployeeOnly([Service] EmployeeRepository employeeRepository) =>
            employeeRepository.GetEmployees();

        public List<Model.Employee> AllEmployeeWithDepartment([Service] EmployeeRepository employeeRepository) =>
            employeeRepository.GetEmployeesWithDepartment();

        //create a subscription with Topic "ReturnedEmployee"
        public async Task<Model.Employee> GetEmployeeById([Service] EmployeeRepository employeeRepository,
            [Service] ITopicEventSender eventSender, int id)
        {
            Model.Employee gottenEmployee = employeeRepository.GetEmployeeById(id);
            await eventSender.SendAsync("ReturnedEmployee", gottenEmployee);
            return gottenEmployee;
        }
    }
}