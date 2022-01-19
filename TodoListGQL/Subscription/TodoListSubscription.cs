using HotChocolate;
using HotChocolate.Types;
using TodoListGQL.Entity;

namespace TodoListGQL.Subscription
{
    public class TodoListSubscription
    {
        [Subscribe]
        [Topic]
        public TodoList OnListAdded([EventMessage] TodoList list) => list;
    }
}