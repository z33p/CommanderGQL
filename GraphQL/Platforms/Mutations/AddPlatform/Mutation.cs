using System.Threading.Tasks;
using CommanderGQL.Data;
using CommanderGQL.GraphQL.Platforms.Mutations.AddPlatform;
using HotChocolate;
using HotChocolate.Data;

namespace CommanderGQL.GraphQL
{
    public partial class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput input, [ScopedService] AppDbContext context)
        {
            var platform = input.toEntity();

            context.Platforms.Add(platform);
            await context.SaveChangesAsync();

            return new AddPlatformPayload(platform);
        }
    }
}