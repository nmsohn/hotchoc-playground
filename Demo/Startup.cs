using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Employee;
using Demo.Mutation;
using Demo.Query;
using Demo.Repository;
using Demo.Subscription;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Demo
{
    public class Startup
    {
        private readonly string AllowedOrigin = "allowedOrigin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DemoDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SampleAppDbContext")));

            services.AddInMemorySubscriptions();

            services
                .AddGraphQLServer()
                .AddQueryType<DepartmentQuery>()
                .AddQueryType<EmployeeQuery>()
                .AddMutationType<DepartmentMutation>()
                .AddMutationType<EmployeeMutation>()
                .AddSubscriptionType<DepartmentSubscription>()
                .AddSubscriptionType<EmployeeSubscription>();

            services.AddScoped<EmployeeRepository, EmployeeRepository>();
            services.AddScoped<DepartmentRepository, DepartmentRepository>();
            
            services.AddCors(option => {
                option.AddPolicy("allowedOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapGraphQL(); });
        }
    }
}