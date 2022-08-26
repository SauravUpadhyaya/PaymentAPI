using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

namespace PaymentAPI
{
    public static class RegisterDependentServices
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder  builder)
        {
            //Register your dependencies
            builder.Services.AddDbContext<PaymentDetailContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer();
            builder.Services.AddAuthorization();

            return builder;
        }
    }
}

