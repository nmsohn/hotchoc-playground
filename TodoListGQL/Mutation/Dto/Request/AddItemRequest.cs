namespace TodoListGQL.Mutation.Dto
{
    public record AddItemRequest(string title, string description, bool done, int todoListId);
}