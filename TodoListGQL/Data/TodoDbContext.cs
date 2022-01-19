using Microsoft.EntityFrameworkCore;
using TodoListGQL.Entity;

namespace TodoListGQL.Data
{
    public class TodoDbContext : DbContext
    {
        public virtual DbSet<TodoItem> Items {get;set;}
        public virtual DbSet<TodoList> Lists {get;set;}

        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TodoItem>(entity =>
            {
                entity.HasOne(d => d.TodoList)
                    .WithMany(p => p.TodoItems)
                    .HasForeignKey(d => d.TodoListId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TodoItem_TodoList");
            });
        }
    }
}