using Domain.Common;
using IHasName = Domain.Common.IHasName;

namespace Common.Api.Graphql.Persistence.Models
{
    public class Address : EntityBase, IHasName
    {
        public string Name { get; set; } = string.Empty;
        public int? Number { get; set; }
        public string? ZipCode { get; set; }
        
        public virtual int? PersonId { get; set; }
        
        public virtual Person? Person { get; set; }
    }
}
