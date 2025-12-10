using SimpleCleanArchitecture.Application;
using SimpleCleanArchitecture.Infrastructure;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddSwaggerGen(c => {
        c.SwaggerDoc("v1", new OpenApiInfo {
            Title = "Simple Clean Architecture",
            Version = "V1"
        });
    });
    builder.Services
        .AddInfrastructure()
        .AddApplication()
        .AddControllers();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple Clean Architecture");
    });
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
