namespace Submission.API.Endpoints
{
    public static class EndpointRegistration 
    {
           public static IEndpointRouteBuilder RegisterEndpoints(this IEndpointRouteBuilder endpoints)
        {
            CreateArticleEndpoint.Map(endpoints);
            return endpoints;
        }

    }
} 
