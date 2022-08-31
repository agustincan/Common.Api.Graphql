


using GraphQL.Types;

namespace Common.Api.Graphql.Graphql.GraphqlPreventiveAction
{
    public interface IPreventiveActionSchema : ISchema
    {

    }
    public class PreventiveActionSchema : Schema
    {
        //public CorrectiveActionSchema(IDependencyResolver resolver) : base(resolver)
        //{
        //    Query = resolver.Resolve<CorrectiveActionQuery>();
        //    //Mutation = resolver.Resolve<Mutacion>();
        //}
        public PreventiveActionSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<PreventiveActionQuery>();
        }
    }
}
