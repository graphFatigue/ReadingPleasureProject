using Microsoft.OpenApi.Models;
using ReadingPleasure.API.Middleware;
using ReadingPleasure.Application;
using ReadingPleasure.Infrastructure;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer ...\"",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors();

builder.Services.AddAuthorization();

builder.Services.ConfigureApplicationLayerDependencies(builder.Configuration);
builder.Services.ConfigureInfrastructureLayerDependencies(builder.Configuration);

builder.Services.AddCors();//(options =>
//{
//    options.AddPolicy(MyAllowSpecificOrigins,
//                          policy =>
//                          {
//                              policy.WithOrigins("http://localhost:4200")
//                                                  .AllowAnyHeader()
//                                                  .AllowAnyMethod();
//                          });
//});

var app = builder.Build();

app.UseExceptionHandlingMiddleware();
//app.UseApiResponseWrapperMiddleware();

//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

app.MapControllers();

app.Run();