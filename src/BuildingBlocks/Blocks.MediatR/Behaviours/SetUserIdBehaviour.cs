using Blocks.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocks.MediatR.Behaviours
{
    public class SetUserIdBehaviour <TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IAuditableAction
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            request.CreatedById = 1; // This is a placeholder. In a real application, you would retrieve the user ID from the context or authentication token.
            return await next();
        }
        
    }
}
