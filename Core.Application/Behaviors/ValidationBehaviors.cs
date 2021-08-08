using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using System.Threading;

namespace Core.Application.Behaviors
{
    public class ValidationBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TResponse : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> Validator;

        public ValidationBehaviors(IEnumerable<IValidator<TRequest>> validator)
        {
            Validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, 
            CancellationToken cancellationToken, 
            RequestHandlerDelegate<TResponse> next)
        {
            if (Validator.Any())
            {
                ValidationContext<TRequest> context = 
                    new ValidationContext<TRequest>(request);
                var validationResult = await Task.WhenAll(Validator
                    .Select(v => v.ValidateAsync(context, cancellationToken)));
                var fails = validationResult
                    .SelectMany(e => e.Errors)
                    .Where(f => f is not null)
                    .ToList();
                if (fails.Any())
                {
                    throw new ValidationException(fails);
                }
            }
            return await next();
        }
    }
}
