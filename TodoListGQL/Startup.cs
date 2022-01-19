using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoListGQL.Configuration;
using TodoListGQL.Data;
using TodoListGQL.Entity;
using TodoListGQL.Mutation;
using TodoListGQL.Query;

namespace TodoListGQL
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContext<TodoDbContext>(options =>
            //     options.UseSqlite(
            //         Configuration.GetConnectionString("DefaultConnection")
            //     ));

            services.AddPooledDbContextFactory<TodoDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")
                ));

            services.AddGraphQLServer()
                // .AddQueryType<DbLoggerCategory.Query>()
                .AddQueryType(d => d.Name("Query"))
                .AddTypeExtension<TodoItemQuery>()
                .AddTypeExtension<TodoListQuery>()
                .AddMutationType(d => d.Name("Mutation"))
                .AddType<TodoListMutation>()
                .AddType<TodoItemMutation>()
                .AddType<ItemType>()
                .AddType<ListType>()
                .AddProjections()
                .AddSorting()
                .AddFiltering()
                .AddInMemorySubscriptions();
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

            app.UseGraphQLVoyager(new VoyagerOptions()
            {
                GraphQLEndPoint = "/graphql"
            }, "/graphql-voyager");
            
            app.UseWebSockets();
        }
    }
}