using Common.Api.Graphql.Graphql.AddressSchema;
using Common.Api.Graphql.Persistence;
using Common.Api.Graphql.Persistence.Models;

namespace Common.Api.Graphql.Graphql.PersonSchema
{
    [ExtendObjectType(typeof(Query))]
    public class PersonQuery
    {
        [UseDbContext(typeof(AppDbContext))]
        //[UsePaging]
        //[UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable PersonType.")]
        public IQueryable<Person> GetPersons([ScopedService] AppDbContext context)
            => context.Persons;
    }
}
