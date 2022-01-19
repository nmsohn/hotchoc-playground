using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using TodoListGQL.Data;
using TodoListGQL.Entity;
using TodoListGQL.Mutation.Dto;

namespace TodoListGQL.Mutation
{
    [ExtendObjectType("Mutation")]
    public class TodoItemMutation
    {
        [UseDbContext(typeof(TodoDbContext))]
        public async Task<AddItemResponse> AddItemAsync(AddItemRequest request, [ScopedService] TodoDbContext context)
        {
            var item = new TodoItem 
            {
                Description = request.description,
                Done = request.done,
                Title = request.title,
                TodoListId = request.todoListId
            };

            context.Items.Add(item);
            await context.SaveChangesAsync();

            return new AddItemResponse(item);
        }
    }
}