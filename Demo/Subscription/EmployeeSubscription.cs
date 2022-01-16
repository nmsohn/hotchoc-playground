using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace Demo.Subscription
{
    public class EmployeeSubscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Model.Employee>> OnEmployeeGet([Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Model.Employee>("ReturnedEmployee", cancellationToken);
        }
    }
}