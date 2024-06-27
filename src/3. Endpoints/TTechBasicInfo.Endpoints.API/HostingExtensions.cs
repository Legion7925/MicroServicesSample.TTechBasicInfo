using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Steeltoe.Discovery.Client;
using TTechBasicInfo.Endpoints.API.BackgroundTasks;
using TTechBasicInfo.Infrastructure.Data.Sql.Commands.Common;
using TTechBasicInfo.Infrastructure.Data.Sql.Queries.Common;
using Zamin.Extensions.DependencyInjection;
using Zamin.Infra.Data.Sql.Commands.Interceptors;

namespace TTechBasicInfo.Endpoints.API;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        string cnn = builder.Configuration.GetConnectionString("BasicInfoCommand_ConnectionString");
        builder.Services.AddDiscoveryClient(); 
        builder.Services.AddZaminParrotTranslator(c =>
        {
            c.ConnectionString = cnn;
            c.AutoCreateSqlTable = true;
            c.SchemaName = "dbo";
            c.TableName = "ParrotTranslations";
            c.ReloadDataIntervalInMinuts = 1;
        });

        builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", c=>
        {
            c.Authority = "https://localhost:5001/";
            c.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateAudience = false,
            };
        });

        builder.Services.AddAuthorization(c=>
        {
            c.AddPolicy("BasicInfoPolicy", p =>
            {
                p.RequireAuthenticatedUser();
                p.RequireClaim("scope" , "basicinfo");
            });
        });

        builder.Services.AddZaminWebUserInfoService(c =>
        {
            c.DefaultUserId = "1";
        });

        builder.Services.AddZaminAutoMapperProfiles(option =>
        {
            option.AssmblyNamesForLoadProfiles = "BasicInfo";
        });

        builder.Services.AddZaminMicrosoftSerializer();

        builder.Services.AddZaminInMemoryCaching();

        builder.Services.AddDbContext<TTechBasicInfoCommandDbContext>(c => c.UseSqlServer(cnn).AddInterceptors(new SetPersianYeKeInterceptor(), new AddAuditDataInterceptor()));

        builder.Services.AddDbContext<TTechBasicInfoQueryDbContext>(c => c.UseSqlServer(cnn));

        builder.Services.AddZaminApiCore("Zamin", "BasicInfo");

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddHostedService<EventPublisher>();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHealthChecks().AddDbContextCheck<TTechBasicInfoCommandDbContext>();
        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseZaminApiExceptionHandler();
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapHealthChecks("/health/live" ,new HealthCheckOptions
        {
            Predicate = _ => false
        });
        app.MapHealthChecks("/health/ready");
        app.MapControllers().RequireAuthorization("BasicInfoPolicy");


        return app;
    }
}
