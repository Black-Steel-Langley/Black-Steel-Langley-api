using Black.Steel.Langley.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Black.Steel.Langley.Api.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StoreContext>(options => 
    options.UseSqlite("Data Source= ../Registrar.sqlite", 
    b => b.MigrationsAssembly("Black.Steel.Langley.Api")));

builder.Services.AddCors (options =>
{
    options.AddDefaultPolicy(builder => {
        builder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

string authority = builder.Configuration["Auth0:Authority"] ??
    throw new ArgumentNullException("Auth0:Authority");

string audience = builder.Configuration["Auth0:Authority"] ??
    throw new ArgumentNullException("Auth0:Audience");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.Authority = authority;
        options.Audience = audience;

    }
);

builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("delete:catalog", policy =>
            policy.RequireAuthenticatedUser().RequireClaim("scope", "delete:catalog"));
    }
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
