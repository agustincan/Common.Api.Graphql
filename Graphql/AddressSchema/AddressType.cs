using Common.Api.Graphql.Persistence;
using Common.Api.Graphql.Persistence.Models;

namespace Common.Api.Graphql.Graphql.AddressSchema
{
    public class AddressType : ObjectType<Address> //, ISearchResultType
    {
        protected override void Configure(IObjectTypeDescriptor<Address> descriptor)
        {
            descriptor.Field(d => d.Id);
            descriptor.Field(d => d.Name);
            descriptor.Field(d => d.Active);
            descriptor.Field(d => d.Number);
            descriptor.Field(d => d.ZipCode);
            descriptor.Field(d => d.PersonId).IsProjected(true);
        }
    }
}
