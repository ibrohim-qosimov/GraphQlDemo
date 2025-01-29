
using GraphQlDemo.Mutations;
using GraphQlDemo.Persistance;
using GraphQlDemo.Queries;
using GraphQlDemo.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GraphQlDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddScoped<ProductRepository>();
            builder.Services.AddScoped<UserRepository>();

            builder.Services
                .AddGraphQLServer() // Graph serverni servise siqatida qo'shish
                .AddQueryType<ProductQuery>()
                .AddQueryType<ProductQuery>()// Queryni qo'shsih
                .AddMutationType<ProductMutation>(); // Muatationni qo'shish

            builder.Services.AddDbContext<DemoGhCbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("Db")));

            var app = builder.Build();

            app.MapGraphQL(); // so'rovni /graphql endpointiga yo'naltirish uchun ishlatilyapti ekan deb tushundim 

            app.Run();
        }
    }
}
