using CommanderGQL.Models;

namespace CommanderGQL.GraphQL.Commands.Mutations.AddCommand
{
    public record AddCommandInput(string HowTo, string CommandLine, int platformId)
    {
        public Command toEntity()
        {
            var command = new Command
            {
                HowTo = this.HowTo
                , CommandLine = this.CommandLine
                , PlatformId = this.platformId
            };

            return command;
        }
    };
}