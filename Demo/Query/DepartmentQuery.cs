using System.Collections.Generic;
using Demo.Repository;
using HotChocolate;

namespace Demo.Query
{
    public class DepartmentQuery
    {
        public List<Model.Department> AllDepartmentsOnly([Service] DepartmentRepository departmentRepository) =>
            departmentRepository.GetAllDepartmentOnly();

        public List<Model.Department> AllDepartmentsWithEmployee([Service] DepartmentRepository departmentRepository) =>
            departmentRepository.GetAllDepartmentsWithEmployee();
    }
}