using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using TodoListGQL.Data;
using TodoListGQL.Entity;

namespace TodoListGQL.Configuration
{
    public class ItemType : ObjectType<TodoItem>
    {
        protected override void Configure(IObjectTypeDescriptor<TodoItem> descriptor)
        {
            descriptor.Description("Used to define todo item for a specific list");

            descriptor.Field(x => x.TodoList)
                // .ResolveWith<Resolvers>(p => p.GetList(default!, default!))
                .UseDbContext<TodoDbContext>()
                .Description("This is the list that the item belongs to");
        }

        private class Resolvers
        {
            public TodoList GetList(TodoItem item, [ScopedService] TodoDbContext context)
            {
                return context.Lists.FirstOrDefault(x => x.Id == item.TodoListId);
            }
        }
    }
}