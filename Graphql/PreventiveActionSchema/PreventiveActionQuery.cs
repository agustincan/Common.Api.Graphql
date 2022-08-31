using Common.Api.Graphql.Persistence;

namespace Common.Api.Graphql.Graphql.PreventiveActionSchema
{
    [GraphQLDescription("Represents the queries available for preventive actions")]
    [ExtendObjectType(typeof(Query))]
    public class PreventiveActionQuery {
        
        [UseDbContext(typeof(AppDbContext))]
        //[UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable PreventiveActionType.")]
        public IQueryable<PreventiveActionType> GetPreventiveActions([ScopedService] AppDbContext context)
            => context.PreventiveActions.Select(a => new PreventiveActionType()
            {
                Id = a.Id,
                Description = a.Description,
                Active = a.Active
            });
    }
}
