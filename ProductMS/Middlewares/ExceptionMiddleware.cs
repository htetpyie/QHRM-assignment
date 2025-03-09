namespace ProductMS.Middlewares
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger _logger;

		public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);

				if (context.Response.StatusCode == 404)
				{
					context.Response.Redirect("/Home/NotFoundPage");
				}
			}
			catch (Exception ex)
			{
				HandleException(context, ex);
			}
		}

		public void HandleException(HttpContext context, Exception ex)
		{
			_logger.LogError(ex.Message);
			context.Response.StatusCode = context.Response.StatusCode;
			context.Response.Redirect("/Home/Error/");
		}
	}

	public static class RequestCultureMiddlewareExtensions
	{
		public static IApplicationBuilder UseExceptionMiddleware(
			this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<ExceptionMiddleware>();
		}
	}
}
