using Common.Api.Graphql.Persistence.Models;

namespace Common.Api.Graphql.Graphql.PreventiveActionSchema
{
    public class PreventiveActionType {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; } = true;
    }
}
