using Microsoft.AspNetCore.Authentication.JwtBearer;  // For JWT authentication
using Microsoft.IdentityModel.Tokens;  // For token validation
using Microsoft.OpenApi.Models;  // For Swagger documentation
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add logging services to the container
builder.Services.AddLogging(logging =>
{
	logging.AddConsole();  // Add console logging provider
});

// Configure logging in the application
var loggerFactory = LoggerFactory.Create(loggingBuilder =>
{
	loggingBuilder.AddConsole();  // Add console logging provider
});

var logger = loggerFactory.CreateLogger("Application");

// Example usage of logging
logger.LogInformation("Application started");

// Add services to the container.

builder.Services.AddControllers();  // Add controller services

// Configure Swagger documentation
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "VehicleAuctionCalculator", Version = "v1" });

	// Configure JWT Bearer authentication for Swagger
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		In = ParameterLocation.Header,
		Description = "Please insert JWT with Bearer into field",
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer"
	});

	// Add security requirement for JWT Bearer authentication
	c.AddSecurityRequirement(new OpenApiSecurityRequirement {
	   {
		 new OpenApiSecurityScheme
		 {
		   Reference = new OpenApiReference
		   {
			 Type = ReferenceType.SecurityScheme,
			 Id = "Bearer"
		   }
		 },
		 Array.Empty<string>()
	   }
	});
});

// Authentication Configuration
var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtAudience = builder.Configuration.GetSection("Jwt:Audience").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

// Configure JWT Bearer authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
	 options.TokenValidationParameters = new TokenValidationParameters
	 {
		 ValidateIssuer = true,
		 ValidateAudience = true,
		 ValidateLifetime = true,
		 ValidateIssuerSigningKey = true,
		 ValidIssuer = jwtIssuer,
		 ValidAudience = jwtAudience,
		 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
	 };
 });

builder.Services.AddControllers();  // Add controller services
builder.Services.AddEndpointsApiExplorer();  // Add API explorer services
builder.Services.AddSwaggerGen();  // Add Swagger generation services

// CORS Configuration
builder.Services.AddCors(options =>
{
	// Configure CORS policy to allow requests from a specific origin
	options.AddPolicy("AllowSpecificOrigin",
		builder => builder.WithOrigins("http://localhost:8080")
						  .AllowAnyHeader()
						  .AllowAnyMethod());
});

// Add services to the container.

var app = builder.Build();

//This line of code app.UseCors("AllowSpecificOrigin"); is applying a Cross - Origin Resource Sharing(CORS) policy to the application. CORS is a security feature implemented by web browsers to restrict web pages from making requests to a different domain than the one that served the original web page.
//In this case, the "AllowSpecificOrigin" policy allows requests from a specific origin (http://localhost:8080). This means that the application will accept requests coming from http://localhost:8080, allowing cross-origin requests from this specific origin.
//By using app.UseCors("AllowSpecificOrigin");, the application is configured to accept requests from the specified origin, enabling cross-origin requests from that origin to access resources in the application.

app.UseCors("AllowSpecificOrigin");  // Apply CORS policy to the application

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();  // Enable Swagger middleware
	app.UseSwaggerUI();  // Enable Swagger UI middleware
}

app.UseHttpsRedirection();  // Redirect HTTP to HTTPS

// Enable authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

// Map controllers to routes
app.MapControllers();

// Final middleware for handling requests
app.Run();


//What is a Middleware

//Middleware in ASP.NET Core is software that handles HTTP requests and responses. It sits between the client and the server and can process, modify, or pass along requests before they reach your application's endpoints (controllers) or modify responses before they are sent back to the client.

//Think of middleware as layers of an onion.
//Each layer can inspect, modify, or handle the request before passing it to the next layer.
//It's like a pipeline where each middleware component can process the request and pass it on to the next component.
//Design Pattern and Principles Applied
//Design Pattern: The code uses the Dependency Injection (DI) design pattern, which allows components to be loosely coupled and easily testable. For example, the AddAuthentication method uses DI to inject the JwtBearerOptions instance.

//Principles:
//Single Responsibility Principle (SRP): Each method or class has a single responsibility.
//For example,the AddSwaggerGen method is responsible for configuring Swagger documentation.

//Dependency Injection (DI): The code uses DI to inject dependencies like AddJwtBearer(options) into classes, making them easier to test and maintain.
//Separation of Concerns (SoC): Each class or method has a single concern, such as authentication, or CORS policy setup.