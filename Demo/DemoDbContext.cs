using Microsoft.EntityFrameworkCore;

namespace Demo
{
    public class DemoDbContext : DbContext
    {
        public DbSet<Model.Employee> Employee { get; set; }

        public DbSet<Model.Department> Department { get; set; }
    }
}