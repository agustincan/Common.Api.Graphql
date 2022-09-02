using Common.Api.Graphql.Dtos;
using Common.Api.Graphql.Repository;

namespace Common.Api.Graphql.Graphql.AddressSchema
{
    public class AddressDataLoader: BatchDataLoader<int, AddressDto>
    {
        private readonly AddressRepo addressRepo;
        public AddressDataLoader(AddressRepo addressRepo,
            IBatchScheduler batchScheduler,
            DataLoaderOptions options = null)
            : base(batchScheduler, options)
        {
            this.addressRepo = addressRepo;
        }

        protected override async Task<IReadOnlyDictionary<int, AddressDto>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var instructors = await addressRepo.GetManyByIds(keys);

            return instructors.ToDictionary(i => i.Id);
        }
    }
}
