using System.Threading;
using System.Threading.Tasks;
using CommanderGQL.Data;
using CommanderGQL.GraphQL.Platforms.Mutations.AddPlatform;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;

namespace CommanderGQL.GraphQL
{
    public partial class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(
            AddPlatformInput input
            , [ScopedService] AppDbContext context
            , [Service] ITopicEventSender eventSender
            , CancellationToken cancellationToken
        )
        {
            var platform = input.toEntity();

            context.Platforms.Add(platform);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationToken);

            return new AddPlatformPayload(platform);
        }
    }
}