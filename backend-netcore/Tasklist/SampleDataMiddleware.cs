using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Tasklist.Infra;

namespace Tasklist.API
{
    public class SampleDataMiddleware
    {
        private readonly RequestDelegate _next;

        public SampleDataMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // Scoped DbContext is injected into Invoke
        public async Task Invoke(HttpContext httpContext, DbContext svc)
        {
            TestData.AddTestData(svc);
            await _next(httpContext);
        }
    }

    public static class SampleDataMiddlewareExtensions
    {
        public static IApplicationBuilder UseSampleData(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SampleDataMiddleware>();
        }
    }
}
