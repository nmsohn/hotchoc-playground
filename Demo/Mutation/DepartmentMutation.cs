using System.Threading.Tasks;
using Demo.Employee;
using Demo.Repository;
using HotChocolate;
using HotChocolate.Subscriptions;

namespace Demo.Mutation
{
    public class DepartmentMutation
    {
        public async Task<Model.Department> CreateDepartment([Service] DepartmentRepository departmentRepository,
            [Service] ITopicEventSender eventSender, string departmentName)
        {
            var newDepartment = new Model.Department
            {
                Name = departmentName
            };
            var createdDepartment = await departmentRepository.CreateDepartment(newDepartment);

            await eventSender.SendAsync("DepartmentCreated", createdDepartment);

            return createdDepartment;
        }
    }
}