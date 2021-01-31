using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Path.TestCase.Api.Filters {
	public class ModelStateFilter : IAsyncActionFilter {
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
			if (!context.ModelState.IsValid) {
				var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
					.SelectMany(v => v.Errors)
					.Select(v => v.ErrorMessage)
					.ToList();

				var message = string.Join(" , ", errors);

				// throw new ModelValidationException(message);
				throw new Exception(message);
			}

			await next();
		}
	}
}