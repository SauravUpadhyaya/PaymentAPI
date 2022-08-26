using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;

public class Startup
{
     public Startup(IConfiguration configuration)
        {
         Configuration = configuration;
        }
     public IConfiguration Configuration{ get;}
  

     public void ConfigureServices(IServiceCollection services)
        {
         services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer();
         services.AddAuthorization();
    }

     public void Configure(WebApplication app, IWebHostEnvironment env)
        {
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        app.MapGet("/", () =>
        {

        }).RequireAuthorization();
        app.Run();
    }
}



