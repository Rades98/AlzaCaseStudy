using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApplicationLayer.Pipelines
{
	/// <summary>
	/// Generic logging pipeline
	/// </summary>
	/// <typeparam name="TRequest">Request</typeparam>
	/// <typeparam name="TResponse">Response</typeparam>
	public class RequestLoggingPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{
		private readonly Stopwatch _stopwatch;
		private readonly ILogger<TRequest> _logger;

		public RequestLoggingPipeline(ILogger<TRequest> logger) => (_stopwatch, _logger) = (new(), logger);

		public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
		{
			_stopwatch.Start();
			var reqResponse = await next();
			_stopwatch.Stop();

			long duration = _stopwatch.ElapsedMilliseconds;

			if (duration > 2000)
			{
				_logger.LogWarning("Request {name} is slow ({duration} ms) : {request}", request.GetType().Name, duration, request);
			}
			else
			{
				_logger.LogInformation("Request {name} ({duration} ms) : {request}", request.GetType().Name, duration, request);
			}

			return reqResponse;
		}
	}
}
