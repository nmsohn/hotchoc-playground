using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using TodoListGQL.Data;
using TodoListGQL.Entity;

namespace TodoListGQL.Query
{
    [ExtendObjectType("Query")]
    public class TodoItemQuery
    {
        [UseDbContext(typeof(TodoDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<TodoItem> GetItem([ScopedService] TodoDbContext context)
        {
            return context.Items;
        }
    }
}