using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure Services 
builder.Services.AddInfrastructure();

// Add core services
builder.Services.AddCore();

// Add Controllers to the service Collection
builder.Services.AddControllers().AddJsonOptions(options =>
   { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
 });

// Add  
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);


//Fluent Validation Auto mapping
builder.Services.AddFluentValidationAutoValidation();

// Build the web application
var app = builder.Build();

app.UseExceptionHandlingMiddleware();

// Roiuting 
app.UseRouting();

// Auth
app.UseAuthentication();
app.UseAuthorization();

// Controller routes
app.MapControllers();

app.Run();
