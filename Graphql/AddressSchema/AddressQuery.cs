using Common.Api.Graphql.Persistence;
using Common.Api.Graphql.Persistence.Models;

namespace Common.Api.Graphql.Graphql.AddressSchema
{
    [ExtendObjectType(typeof(Query))]
    public class AddressQuery
    {
        [UseDbContext(typeof(AppDbContext))]
        //[UsePaging]
        //[UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable AddressType.")]
        public IQueryable<Address> GetAddresses([ScopedService] AppDbContext context)
            => context.Addresses;
    }
}
