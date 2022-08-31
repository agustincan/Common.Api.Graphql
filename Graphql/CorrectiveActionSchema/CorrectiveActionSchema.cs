


using GraphQL.Types;

namespace Common.Api.Graphql.Graphql.GraphqlCorrectiveAction
{
    public interface ICorrectiveActionSchema: ISchema
    {

    }
    public class CorrectiveActionSchema : Schema
    {
        //public CorrectiveActionSchema(IDependencyResolver resolver) : base(resolver)
        //{
        //    Query = resolver.Resolve<CorrectiveActionQuery>();
        //    //Mutation = resolver.Resolve<Mutacion>();
        //}
        public CorrectiveActionSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<CorrectiveActionQuery>();
        }
    }
}
