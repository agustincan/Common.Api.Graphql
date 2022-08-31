using Common.Api.Graphql.Graphql.PreventiveActionSchema;
using Common.Api.Graphql.Persistence;
using Common.Api.Graphql.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Common.Api.Graphql.Repository
{
    public interface IPreventiveActionRepo
    {
        Task<PreventiveActionResult> CreatePreventiveAction(string name);
        Task<PreventiveActionResult> UpdatePreventiveAction(int id, string name);
        Task<bool> DeletePreventiveAction(int id);
    }
    public class PreventiveActionRepo : IPreventiveActionRepo
    {
        private readonly IDbContextFactory<AppDbContext> dbcContextFactory;

        public PreventiveActionRepo(IDbContextFactory<AppDbContext> dbcContextFactory)
        {
            this.dbcContextFactory = dbcContextFactory;
        }

        public async Task<PreventiveActionResult> CreatePreventiveAction(string name)
        {
            var newObject = new PreventiveAction()
            {
                Description = name
            };
            using (var dbcontext = await dbcContextFactory.CreateDbContextAsync())
            {
                await dbcontext.PreventiveActions.AddAsync(newObject);
                await dbcontext.SaveChangesAsync();
            }
                
            PreventiveActionResult result = new()
            {
                id = newObject.Id,
                description = newObject.Description
            };

            return result;
        }
        public async Task<PreventiveActionResult> UpdatePreventiveAction(int id, string name)
        {
            PreventiveAction? objectToUpdate = null;
            using (var dbcontext = await dbcContextFactory.CreateDbContextAsync())
            {
                objectToUpdate = await dbcontext.PreventiveActions.FindAsync(id);
                if (objectToUpdate == null) throw new GraphQLException($"Preventive Action {id} not exists");

                objectToUpdate.Description = name;
                dbcontext.PreventiveActions.Update(objectToUpdate);
                await dbcontext.SaveChangesAsync();
            }

            PreventiveActionResult result = new()
            {
                id = objectToUpdate.Id,
                description = objectToUpdate.Description
            };

            return result;
        }

        public async Task<bool> DeletePreventiveAction(int id)
        {
            using (var dbcontext = await dbcContextFactory.CreateDbContextAsync())
            {
                var toDelete = await dbcontext.PreventiveActions.FindAsync(id);
                if (toDelete == null) return false;
                toDelete.Active = false;
                dbcontext.PreventiveActions.Update(toDelete);
                return await dbcontext.SaveChangesAsync() > 0;
            }
        }
    }
}
