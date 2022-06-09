// global using EggStore.Infrastucture.Shareds.DataAccess;
global using Microsoft.EntityFrameworkCore;
using EggStore.Domains.Mails.Interface;
using EggStore.Domains.Mails.Models;
using EggStore.Domains.Mails.Services;
using EggStore.Domains.Packages.Repositories;
using EggStore.Domains.Packages.Validators;
using EggStore.Domains.Users.Repositories;
using EggStore.Infrastucture.Middlewares;
using EggStore.Infrastucture.Shareds.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Newtonsoft.Json.Serialization;
using EggStore.Domains.Eggs.Repositories;
using EggStore.Domains.Eggs.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add database to service.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add repository to service. 
builder.Services.AddScoped<PackagesRepository>();
builder.Services.AddScoped<UsersRepository>();
builder.Services.AddScoped<EggsRepository>();

// Add validator
builder.Services.AddScoped<PackagesValidator>();
builder.Services.AddScoped<EggsValidator>();

// Add jwt config
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// Add Email Configuration
builder.Services.Configure<EmailConfiguration>(builder.Configuration.GetSection("EmailConfiguration"));
builder.Services.AddSingleton<IEmailSender, EmailSender>();

// Add controller to  service
builder.Services.AddControllers();

builder.Services.AddMvc(option => option.EnableEndpointRouting = false)
                //.AddFluentValidation(s =>
                //{
                //    //s.RegisterValidatorsFromAssemblyContaining<Startup>();
                //    //s.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                //})
                .AddNewtonsoftJson(options =>
                 {
                     options.SerializerSettings.ContractResolver = new DefaultContractResolver()
                     {
                         NamingStrategy = new SnakeCaseNamingStrategy()
                     };
                 });


// Add Logger to service
builder.Host.ConfigureLogging(options =>
{
    options.ClearProviders();
    options.AddConsole();
});

// Add swagger config to service
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test02", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."

    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
});

// Configure sentry
builder.WebHost.UseSentry(o =>
{
    o.Dsn = "https://ba244ba1e19d4ab0bc9fe2a3fd56188c@o1278378.ingest.sentry.io/6477701";
    o.Debug = true;
    o.TracesSampleRate = 1.0;
});

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

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseSentryTracing();

app.UseMvc();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
