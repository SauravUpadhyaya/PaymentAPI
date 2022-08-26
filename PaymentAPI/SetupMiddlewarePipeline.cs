using System;
namespace PaymentAPI
{
    public static class SetupMiddlewarePipeline
    {
        public static WebApplication SetupMiddleware(this WebApplication app)
        {
            //Configure the pipeline
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.MapGet("/", () =>
            {

            }).RequireAuthorization();
            return app;
        }
    }
}

