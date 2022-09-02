using Common.Api.Graphql.Graphql.AddressSchema;
using Common.Api.Graphql.Persistence;
using Common.Api.Graphql.Persistence.Models;
using Common.Api.Graphql.Repository;
using Microsoft.EntityFrameworkCore;

namespace Common.Api.Graphql.Graphql.PersonSchema
{
    public class PersonType : ObjectType<Person>
    {

        protected override void Configure(IObjectTypeDescriptor<Person> descriptor)
        {
            
            descriptor.Field(d => d.Id);
            descriptor.Field(d => d.Name);
            descriptor.Field(d => d.Active);
            descriptor.Field(d => d.Adresses)
                .ResolveWith<Resolvers>(r => r.GetAddresses(default!, default!));
        }
        private class Resolvers
        {
            private readonly IDbContextFactory<AppDbContext> dbcContextFactory;

            public Resolvers(IDbContextFactory<AppDbContext> dbcContextFactory)
            {
                this.dbcContextFactory = dbcContextFactory;
            }

            [UseDbContext(typeof(AppDbContext))]
            public IQueryable<Address> GetAddresses([Parent] Person person, [ScopedService] AppDbContext dbContext)
            {
                using (AppDbContext dbcontext = dbcContextFactory.CreateDbContext())
                {
                    return dbContext.Addresses.Where(p => p.PersonId != null && p.PersonId == person.Id);
                }
            }
        }
    }
}
