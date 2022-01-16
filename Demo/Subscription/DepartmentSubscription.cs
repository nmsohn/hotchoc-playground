using System.Threading;
using System.Threading.Tasks;
using Demo.Model;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace Demo.Subscription
{
    public class DepartmentSubscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Department>> OnDepartmentCreate(
            [Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Department>("DepartmentCreated", cancellationToken);
        }
    }
}