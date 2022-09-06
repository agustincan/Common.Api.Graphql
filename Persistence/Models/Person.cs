using Domain.Common;
using IHasName = Domain.Common.IHasName;

namespace Common.Api.Graphql.Persistence.Models
{
    public class Person : EntityBase, IHasName
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<Address> Adresses { get; set; } = default!;
    }
}
