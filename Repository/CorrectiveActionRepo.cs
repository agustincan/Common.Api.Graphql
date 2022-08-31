using Common.Api.Graphql.Graphql.CorrectiveActionSchema;
using Common.Api.Graphql.Persistence;
using Common.Api.Graphql.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Common.Api.Graphql.Repository
{
    public interface ICorrectiveActionRepo
    {
        Task<CorrectiveActionResult> CreateCorrectiveAction(string name);
        Task<CorrectiveActionResult> UpdateCorrectiveAction(int id, string name);
        Task<bool> DeleteCorrectiveAction(int id);
    }
    public class CorrectiveActionRepo: ICorrectiveActionRepo
    {
        private readonly IDbContextFactory<AppDbContext> dbcContextFactory;

        public CorrectiveActionRepo(IDbContextFactory<AppDbContext> dbcContextFactory)
        {
            this.dbcContextFactory = dbcContextFactory;
        }

        public async Task<CorrectiveActionResult> CreateCorrectiveAction(string name)
        {
            var newObject = new CorrectiveAction()
            {
                Description = name
            };
            using (var dbcontext = await dbcContextFactory.CreateDbContextAsync())
            {
                dbcontext.CorrectiveActions.Add(newObject);
                await dbcontext.SaveChangesAsync();
            }
                
            CorrectiveActionResult result = new()
            {
                id = newObject.Id,
                description = newObject.Description
            };

            return result;
        }
        public async Task<CorrectiveActionResult> UpdateCorrectiveAction(int id, string name)
        {
            CorrectiveAction? objectToUpdate = null;
            using (var dbcontext = await dbcContextFactory.CreateDbContextAsync())
            {
                objectToUpdate = await dbcontext.CorrectiveActions.FindAsync(id);
                if (objectToUpdate == null) throw new GraphQLException($"Corrective Action {id} not exists");

                objectToUpdate.Description = name;
                dbcontext.CorrectiveActions.Update(objectToUpdate);
                await dbcontext.SaveChangesAsync();
            }

            CorrectiveActionResult result = new()
            {
                id = objectToUpdate.Id,
                description = objectToUpdate.Description
            };

            return result;
        }

        public async Task<bool> DeleteCorrectiveAction(int id)
        {
            using (var dbcontext = await dbcContextFactory.CreateDbContextAsync())
            {
                var toDelete = await dbcontext.CorrectiveActions.FindAsync(id);
                if (toDelete == null) return false;
                toDelete.Active = false;
                dbcontext.CorrectiveActions.Update(toDelete);
                return await dbcontext.SaveChangesAsync() > 0;
            }
        }
    }
}
