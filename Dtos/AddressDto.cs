namespace Common.Api.Graphql.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? Number { get; set; }
        public string? ZipCode { get; set; }
    }
}
