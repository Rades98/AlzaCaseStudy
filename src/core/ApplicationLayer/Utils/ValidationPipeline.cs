namespace ApplicationLayer.Utils
{
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Generic validation pipeline
    /// </summary>
    /// <typeparam name="TRequest">Request</typeparam>
    /// <typeparam name="TResponse">Response</typeparam>
    public class ValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ILogger<TRequest> _logger;

        public ValidationPipeline(IEnumerable<IValidator<TRequest>> validators, ILogger<TRequest> logger) => (_validators, _logger) = (validators, logger);

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
                .Select(validation => validation.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null && failure.Severity == Severity.Error)
                .ToList();

            var warnings = _validators
                .Select(validation => validation.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null && failure.Severity == Severity.Warning)
                .ToList();

            if (failures.Count != 0)
            {
                failures.ForEach(f => _logger.LogError(f.ErrorMessage));
                throw new ValidationException(failures);
            }

            if (warnings.Count != 0)
            {
                failures.ForEach(f => _logger.LogWarning(f.ErrorMessage));
            }

            return next();
        }
    }
}
