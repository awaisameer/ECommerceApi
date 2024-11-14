using ECommerceApi.GraphQL.Types;
using ECommerceApi.GraphQL.Mutations;
using ECommerceApi.GraphQL.Queries;
using Microsoft.EntityFrameworkCore;
using HotChocolate;
using ECommerceApi.GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Enable logging for better debugging
builder.Logging.AddConsole();

// Configure DbContext with PostgreSQL
builder.Services.AddDbContext<ECommerceDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        npgsqlOptions => npgsqlOptions.MigrationsAssembly("ECommerceApi")));

// Register GraphQL services with dynamic query and mutation
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()  // Register all queries
    .AddMutationType<Mutation>(); // Register all mutations

// Register scoped services for queries and mutations
builder.Services.AddScoped<ProductQueries>();
builder.Services.AddScoped<CustomerQueries>();
builder.Services.AddScoped<OrderQueries>();
builder.Services.AddScoped<ProductMutations>();
builder.Services.AddScoped<CustomerMutations>();
builder.Services.AddScoped<OrderMutations>();

// Add services for controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Enable GraphQL Playground for testing queries
    app.MapGraphQL(); // This will automatically map the default GraphQL endpoint
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Map controllers (if you're using regular API controllers)
app.MapControllers();

app.Run();
