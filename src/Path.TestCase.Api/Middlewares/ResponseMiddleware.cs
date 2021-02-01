using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Path.TestCase.Core.Models;

namespace Path.TestCase.Api.Middlewares {
	public class ResponseMiddleware {
		private readonly RequestDelegate _next;

		public ResponseMiddleware(RequestDelegate next) {
			_next = next;
		}

		public async Task Invoke(HttpContext context) {
			if (context.Request.Path.StartsWithSegments("/chatHub")) {
				await _next(context);
				return;
			}

			var currentBody = context.Response.Body;

			await using var memoryStream = new MemoryStream();
			context.Response.Body = memoryStream;

			await _next(context);

			context.Response.Body = currentBody;

			try {
				memoryStream.Seek(0, SeekOrigin.Begin);
				var readToEnd = await new StreamReader(memoryStream).ReadToEndAsync();

				if (context.Response.StatusCode != StatusCodes.Status200OK)
					return;

				var objResult = JsonConvert.DeserializeObject(readToEnd);

				context.Response.ContentType = "application/json";
				await context.Response.WriteAsync(
					JsonConvert.SerializeObject(
						new Response<object>().SetResult(objResult)
							.SetVersion(context.GetRequestedApiVersion()?.ToString())));
			} catch (Exception e) {
				throw;
			}
		}
	}
}