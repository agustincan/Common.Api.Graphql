using Common.Api.Graphql.Dtos;
using Common.Api.Graphql.Persistence;
using Common.Api.Graphql.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Common.Api.Graphql.Repository
{
    public interface IAddressRepo
    {
        //IQueryable<Address> GetQueryableByPersonId(int personId);
        Task<AddressDto> GetById(int id);
        Task<IEnumerable<AddressDto>> GetManyByIds(IReadOnlyList<int> Ids);
    }

    public class AddressRepo : IAddressRepo
    {
        private readonly IDbContextFactory<AppDbContext> dbcContextFactory;

        public AddressRepo(IDbContextFactory<AppDbContext> dbcContextFactory)
        {
            this.dbcContextFactory = dbcContextFactory;
        }

        //public IQueryable<Address> GetQueryableById(int id)
        //{
        //    using (AppDbContext context = dbcContextFactory.CreateDbContext())
        //    {
        //        return context.Addresses.Where(a => a.Id == id);
        //    }
        //}

        //public IQueryable<Address> GetQueryableByPersonId(int personId)
        //{
        //    using (AppDbContext context = dbcContextFactory.CreateDbContext())
        //    {
        //        return context.Addresses.Where(a => a.PersonId == personId);
        //    }
        //}

        public async Task<AddressDto> GetById(int id)
        {
            var res = await GetManyByIds(new int[] { id });
            return res?.FirstOrDefault()!;
        }

        public async Task<IEnumerable<AddressDto>> GetManyByIds(IReadOnlyList<int> Ids)
        {
            using (AppDbContext context = dbcContextFactory.CreateDbContext())
            {
                return (IEnumerable<AddressDto>)await context.Addresses
                    .Where(i => Ids.Contains(i.Id))
                    .ToListAsync();
            }
        }
    }
}
