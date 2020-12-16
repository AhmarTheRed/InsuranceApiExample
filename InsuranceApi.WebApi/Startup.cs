using System.Linq;
using InsuranceApi.Domain.Interfaces;
using InsuranceApi.FakeOperations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace InsuranceApi.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services
                .AddApiVersioning(o =>
                {
                    o.DefaultApiVersion = new ApiVersion(1, 0);
                    o.AssumeDefaultVersionWhenUnspecified = true;
                    o.ReportApiVersions = true;
                });
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1.0", new OpenApiInfo {Title = "InsuranceApi.WebApi", Version = "v1.0"});
                    c.SwaggerDoc("v2.0", new OpenApiInfo {Title = "InsuranceApi.WebApi", Version = "v2.0"});
                    c.OperationFilter<RemoveVersionFromParameter>();
                    c.DocumentFilter<ReplaceVersionWithExactValueInPath>();

                    c.DocInclusionPredicate((version, desc) =>
                    {
                        var versions = desc.CustomAttributes()
                            .OfType<ApiVersionAttribute>()
                            .SelectMany(attr => attr.Versions);

                        var maps = desc.CustomAttributes()
                            .OfType<MapToApiVersionAttribute>()
                            .SelectMany(attr => attr.Versions)
                            .ToArray();

                        return versions.Any(v => $"v{v.ToString()}" == version)
                               && (!maps.Any() || maps.Any(v => $"v{v.ToString()}" == version));
                    });
                }
            );

            services
                .AddTransient<IClientRepository, FakeClientRepository>()
                .AddTransient<IPolicyRepository, FakePolicyRepository>()
                .AddTransient<IClaimRepository, FakeClaimRepository>()
                .AddTransient<IDocumentRepository, FakeDocumentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)//, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "v1.0");
                c.SwaggerEndpoint("/swagger/v2.0/swagger.json", "v2.0");
            });
        }
    }
}
