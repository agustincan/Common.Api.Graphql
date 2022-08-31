using Common.Api.Graphql.Persistence.Models;

namespace Common.Api.Graphql.Graphql.CorrectiveActionSchema
{
    public class CorrectiveActionType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; } = true;
    }
}
