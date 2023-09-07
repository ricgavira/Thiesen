using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Thiesen.API.Filters;
using Thiesen.Application.Commands.CreatePessoaFisica;
using Thiesen.Domain.Repositories;
using Thiesen.Domain.Services;
using Thiesen.Infra.Data.AuthService;
using Thiesen.Infra.Data.Context;
using Thiesen.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseSqlServer(connectionString)
          .EnableSensitiveDataLogging());

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));

builder.Services.AddValidatorsFromAssemblyContaining<CreatePessoaFisicaCommand>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreatePessoaFisicaCommand).Assembly));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "Thiesen WebApi", Version = "v1" });
});

builder.WebHost.ConfigureKestrel(option =>
{
    option.ListenAnyIP(5097);
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(x =>
    {
        x.WithExposedHeaders("Set-Authorization")
         .AllowAnyHeader()
         .AllowAnyMethod()
         .AllowCredentials();
    });
});

builder.Services.AddScoped<IPessoaFisicaRepository, PessoaFisicaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "Thiesen WebApi");
        x.RoutePrefix = "swagger";
    });
}

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var dbContext = service.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
