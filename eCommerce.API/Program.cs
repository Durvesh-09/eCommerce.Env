using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure Services 
builder.Services.AddInfrastructure();

// Add core services
builder.Services.AddCore();

// Add Controllers to the service Collection
builder.Services.AddControllers();

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
