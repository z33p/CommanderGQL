using System.Threading.Tasks;
using CommanderGQL.Data;
using CommanderGQL.GraphQL.Commands.Mutations.AddCommand;
using HotChocolate;
using HotChocolate.Data;

namespace CommanderGQL.GraphQL
{
    public partial class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input, [ScopedService] AppDbContext context)
        {
            var command = input.toEntity();

            context.Add(command);
            await context.SaveChangesAsync();

            return new AddCommandPayload(command);
        }
    }
}