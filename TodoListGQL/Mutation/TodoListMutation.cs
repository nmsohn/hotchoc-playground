using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using TodoListGQL.Data;
using TodoListGQL.Entity;
using TodoListGQL.Mutation.Dto;
using TodoListGQL.Subscription;

namespace TodoListGQL.Mutation
{
    [ExtendObjectType("Mutation")]
    public class TodoListMutation
    {
        [UseDbContext(typeof(TodoDbContext))]
        public async Task<AddListResponse> AddListAsync(AddListRequest request, [ScopedService] TodoDbContext context, [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
        {
            var list = new TodoList 
            {
                Name = request.name
            };

            context.Lists.Add(list);
            await context.SaveChangesAsync(cancellationToken);
            await eventSender.SendAsync(nameof(TodoListSubscription.OnListAdded), list, cancellationToken);

            return new AddListResponse(list);
        } 
    }
}