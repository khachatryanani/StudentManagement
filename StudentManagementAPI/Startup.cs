using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StudentManagementAPI.Data;
using StudentManagementAPI.GraphQL.Queries;
using StudentManagementAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Server;
using StudentManagementAPI.GraphQL.Schemas;
using GraphQL.Server.Ui.Voyager;

namespace StudentManagementAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = configuration.GetConnectionString("AzureSQLDatabase");
            //connectionString = configuration.GetValue<string>("AzureSQLDatabase");
        }

        public IConfiguration Configuration { get; }
        private readonly string connectionString;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddGraphQLServer().AddQueryType<UserQuery>();


            services.AddScoped<IDataRepository, DataRep>(dt => new DataRep(connectionString));
            services.AddScoped<UserQuery, UserQuery>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StudentManagementAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StudentManagementAPI v1"));
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
            app.UseGraphQLPlayground();
            //app.UseGraphQLVoyager(new VoyagerOptions()
            //{
            //    GraphQLEndPoint = "/graphql"
            //}, "/graphql-voyager");
            //app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGraphQL();
                endpoints.MapGraphQLPlayground();
                endpoints.MapControllers();
            });
        }
    }
}
