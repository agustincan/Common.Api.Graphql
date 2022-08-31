using Common.Api.Graphql.Repository;

namespace Common.Api.Graphql.Graphql.CorrectiveActionSchema
{
    [ExtendObjectType(typeof(Mutation))]
    public class CorrectiveActionMutation
    {
        private readonly ICorrectiveActionRepo repo;

        public CorrectiveActionMutation(ICorrectiveActionRepo repo)
        {
            this.repo = repo;
        }
        public async Task<CorrectiveActionResult> CreateCorrectiveAction(string name)
        {
            return await repo.CreateCorrectiveAction(name);
        }
        public async Task<CorrectiveActionResult> UpdateCorrectiveAction(int id, string name)
        {
            return await repo.UpdateCorrectiveAction(id, name); ;
        }

        public async Task<bool> DeleteCorrectiveAction(int id)
        {
            return await repo.DeleteCorrectiveAction(id);
        }
    }
}
