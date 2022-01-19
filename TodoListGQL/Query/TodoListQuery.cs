using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using TodoListGQL.DataAccess;
using TodoListGQL.Entity;

namespace TodoListGQL.Query
{
    [ExtendObjectType("Query")]
    public class TodoListQuery
    {
        [UseDbContext(typeof(TodoDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<TodoList> GetLists([ScopedService] TodoDbContext context)
        {
            return context.Lists;
        }
    }
}