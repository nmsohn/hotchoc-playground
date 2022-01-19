using HotChocolate.Types;
using TodoListGQL.Entity;

namespace TodoListGQL.Mutation.Dto
{
    public record AddListResponse(TodoList list);
}