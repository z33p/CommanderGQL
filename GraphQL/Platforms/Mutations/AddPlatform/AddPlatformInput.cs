using CommanderGQL.Models;

namespace CommanderGQL.GraphQL.Platforms.Mutations.AddPlatform
{
    public record AddPlatformInput (string Name)
    {
        public Platform toEntity()
        {
            var platform = new Platform
            {
                Name = this.Name
            };

            return platform;
        }
    };
}