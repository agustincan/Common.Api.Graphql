using Common.Api.Graphql.Persistence;
using Common.Api.Graphql.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Common.Api.Graphql.Repository
{
    public interface IPersonRepo
    {
        Task<IEnumerable<Person>> GetAll();
    }

    public class PersonRepo : IPersonRepo
    {
        private readonly IDbContextFactory<AppDbContext> dbContextFactory;

        public PersonRepo(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            using (var dbcontext = await dbContextFactory.CreateDbContextAsync())
            {
                return dbcontext.Persons.AsNoTracking();
            }
        }
    }
}
