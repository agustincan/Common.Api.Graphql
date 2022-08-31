using Common.Api.Graphql.Graphql;
using Common.Api.Graphql.Graphql.CorrectiveActionSchema;
using Common.Api.Graphql.Graphql.PreventiveActionSchema;
using Common.Api.Graphql.Persistence;
using Common.Api.Graphql.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPooledDbContextFactory<AppDbContext>(opt =>
                opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
                    .LogTo(Console.WriteLine)
                );

//builder.Services.AddDbContext<AppDbContext>(opt =>
//                opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
//                    .LogTo(Console.WriteLine)
//                );

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<CorrectiveActionType>()
    .AddType<PreventiveActionType>()
    .AddTypeExtension<CorrectiveActionQuery>()
    .AddTypeExtension<PreventiveActionQuery>()
    .AddTypeExtension<CorrectiveActionMutation>()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .AddAuthorization();

builder.Services.AddScoped<ICorrectiveActionRepo, CorrectiveActionRepo>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// migrate any database changes on startup (includes initial db creation)
//using (var scope = app.Services.CreateScope())
//{
//    var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//    dataContext.Database.Migrate();
//}

using (IServiceScope scope = app.Services.CreateScope())
{
    IDbContextFactory<AppDbContext> contextFactory =
        scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();

    using (AppDbContext context = contextFactory.CreateDbContext())
    {
        context.Database.Migrate();
    }
}

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.Run();