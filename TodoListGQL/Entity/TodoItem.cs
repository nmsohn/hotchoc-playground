using HotChocolate;

namespace TodoListGQL.Entity
{
    [GraphQLDescription("Todo item for a Todo list")]
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [GraphQLDescription("If the user has completed this item")]
        public bool Done { get; set; }
        [GraphQLDescription("The list which this item belongs to")]
        public int TodoListId { get; set; }

        public virtual TodoList TodoList { get; set; }
    }
}