using System.Collections.Generic;
using HotChocolate;

namespace TodoListGQL.Entity
{
    [GraphQLDescription("A todo list")]
    public class TodoList
    {
        public TodoList()
        {
            TodoItems = new HashSet<TodoItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}