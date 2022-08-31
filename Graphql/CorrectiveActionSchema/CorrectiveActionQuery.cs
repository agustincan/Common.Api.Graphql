using Common.Api.Graphql.Persistence;
using Common.Api.Graphql.Persistence.Models;


namespace Common.Api.Graphql.Graphql.CorrectiveActionSchema
{
    [GraphQLDescription("Represents the queries available for corrective actions")]
    [ExtendObjectType(typeof(Query))]
    public class CorrectiveActionQuery
    {
        [UseDbContext(typeof(AppDbContext))]
        //[UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable CorrectiveAction.")]
        public IQueryable<CorrectiveActionType> GetCorrectiveActions([ScopedService] AppDbContext context)
            => context.CorrectiveActions.Select(a => new CorrectiveActionType()
            {
                Id = a.Id,
                Description = a.Description,
                Active = a.Active
            });
    }
}
