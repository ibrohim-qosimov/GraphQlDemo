
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
                .AddGraphQLServer() // Graph serverni servise siqatida qo'shish
                .AddQueryType<ProductQuery>() // Queryni qo'shsih
                .AddMutationType<ProductMutation>(); // Muatationni qo'shish

            var app = builder.Build();

            app.MapGraphQL(); // so'rovni /graphql endpointiga yo'naltirish uchun ishlatilyapti ekan deb tushundim 

            app.Run();
        }
    }
}
