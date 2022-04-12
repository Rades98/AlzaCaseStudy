namespace ApplicationLayer.Utils
{
	using FluentValidation;
	using MediatR;

	public class ValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;

		public ValidationPipeline(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

		public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
		{
			var context = new ValidationContext<TRequest>(request);

			var failures = _validators
				.Select(validation => validation.Validate(context))
				.SelectMany(result => result.Errors)
				.Where(failure => failure != null && failure.Severity == Severity.Error)
				.ToList();

			//Will be used for logging will be solved in #7
			var warnings = _validators
				.Select(validation => validation.Validate(context))
				.SelectMany(result => result.Errors)
				.Where(failure => failure != null && failure.Severity == Severity.Warning)
				.ToList();


			if (failures.Count != 0)
			{
				throw new ValidationException(failures);
			}

			return next();
		}
	}
}
