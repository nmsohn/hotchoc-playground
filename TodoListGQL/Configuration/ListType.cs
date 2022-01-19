using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using TodoListGQL.DataAccess;
using TodoListGQL.Entity;

namespace TodoListGQL.Configuration
{
    public class ListType : ObjectType<TodoList>
    {
        protected override void Configure(IObjectTypeDescriptor<TodoList> descriptor)
        {
            descriptor.Description("Used to group the do list item into groups");

            descriptor.Field(x => x.TodoItems)
                // .ResolveWith<Resolvers>(p => p.GetItems(default!, default!))
                .UseDbContext<TodoDbContext>()
                .Description("This is the list of to do item available for this list");
        }

        private class Resolvers
        {
            public IQueryable<TodoItem> GetItems(TodoList list, [ScopedService] TodoDbContext dbContext)
            {
                return dbContext.Items.Where(x => x.TodoListId == list.Id);
            }
        }
    }
}