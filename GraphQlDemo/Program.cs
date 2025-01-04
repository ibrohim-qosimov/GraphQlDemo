
using GraphQlDemo.Mutations;
using GraphQlDemo.Persistance;
using GraphQlDemo.Queries;
using GraphQlDemo.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GraphQlDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DemoGhCbContext>(ops =>
            {
                ops.UseNpgsql(builder.Configuration.GetConnectionString("Db"));
            });

            builder.Services.AddScoped<ProductRepository>();

            builder.Services
                .AddGraphQLServer()
                .AddQueryType<ProductQuery>()
                .AddMutationType<ProductMutation>();

            var app = builder.Build();

            app.MapGraphQL();

            app.Run();
        }
    }
}
