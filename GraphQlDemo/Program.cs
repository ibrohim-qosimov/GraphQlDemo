
using GraphQlDemo.Mutations;
using GraphQlDemo.Persistance;
using GraphQlDemo.Queries;
using GraphQlDemo.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            .AddGraphQLServer()
                .AddQueryType<Query>() // Asosiy Query turi
                    .AddTypeExtension<ProductQuery>() // Kengaytmalar
                    .AddTypeExtension<UserQuery>()
                .AddMutationType<Mutation>() // Asosiy Mutation turi
                    .AddTypeExtension<ProductMutation>()
                    .AddTypeExtension<UserMutation>();


            builder.Services.AddDbContext<DemoGhCbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("Db")));

            var app = builder.Build();

            app.MapGraphQL(); // so'rovni /graphql endpointiga yo'naltirish uchun ishlatilyapti ekan deb tushundim 

            app.Run();
        }
    }
}
