
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RaionRecruitmentTaskDomain.Exceptions;
using System.Numerics;

namespace RaionRecruitmentTaskAPI.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next.Invoke(context);
			}
            catch (NotFoundException notFound)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFound.Message);
            }
            catch (WithdrawValueTooHighException valueToHigh)
            {
                context.Response.StatusCode = 422;
                await context.Response.WriteAsync(valueToHigh.Message);
            }
            catch (DbUpdateConcurrencyException)
            {
                context.Response.StatusCode = 409;
                await context.Response.WriteAsync("Concurrency record problem please try again");
            }
            catch (Exception ex)
			{
				//place for log error

				context.Response.StatusCode = 500;
				await context.Response.WriteAsync($"Something went wrong {ex.GetType()}");
			}
        }
    }
}
