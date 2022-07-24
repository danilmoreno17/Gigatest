using Azure.Storage.Blobs;
using Kameyo.Api.Services;
using Kameyo.Core;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Infrastructure;
using Kameyo.Infrastructure.AzureServices;
using Kameyo.Infrastructure.Identity.Entities;
using Kameyo.Infrastructure.Persistence.Contexts;
using Kameyo.Infrastructure.Persistence.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;

//using OpenApiSecurityScheme = NSwag.OpenApiSecurityScheme;
//using NSwag;
///using NSwag.Generation.Processors.Security;


var builder = WebApplication.CreateBuilder(args);

//services.AddControllers().AddNewtonsoftJson();

// Add services to the container.
builder.Services.AddControllers(options =>
{
	var jsonInputFormatter = options.InputFormatters
			.OfType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonInputFormatter>()
			.Single();

	jsonInputFormatter.SupportedMediaTypes.Add("application/json;charset=UTF-8");
	jsonInputFormatter.SupportedMediaTypes.Add("application/x-www-form-urlencoded;charset=UTF-8");
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "v1",
		Title = "Kameyo API",
		Description = "An ASP.NET Core Web API for managing Kameyo App",
		TermsOfService = new Uri("https://example.com/terms"),

		Contact = new Microsoft.OpenApi.Models.OpenApiContact
		{
			Name = "Contact",
			Url = new Uri("https://example.com/contact")
		},
		License = new Microsoft.OpenApi.Models.OpenApiLicense
		{
			Name = "License",
			Url = new Uri("https://example.com/license")
		}
	});
});


builder.Services.AddApplicationCore();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
	builder.WithOrigins("*")
	.AllowAnyMethod()
	.AllowAnyHeader()
	.WithMethods("GET", "PUT", "DELETE", "POST", "PATCH");
}));


//builder.Services
//    .AddControllersWithViews(options => options.Filters.Add<ApiExceptionFilterAttribute>())
//    .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

//builder.Services.AddRazorPages();

// Customise default API behaviour
//builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

// In production, the Angular files will be served from this directory
//builder.Services.AddSpaStaticFiles(configuration => configuration.RootPath = "ClientApp/dist");

//builder.Services.AddOpenApiDocument(configure =>
//{
//    configure.Title = "Giga.Kameyo API";
//    configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
//    {
//        Type = OpenApiSecuritySchemeType.ApiKey,
//        Name = "Authorization",
//        In = OpenApiSecurityApiKeyLocation.Header,
//        Description = "Type into the textbox: Bearer {your JWT token}."
//    });

//    configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
//});

var app = builder.Build();

//EF Migrations and Seed Database
await UseEFMigrations(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	app.UseDeveloperExceptionPage();
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseCors("corsapp");
app.UseHttpsRedirection();

app.UseHealthChecks("/health");
app.UseHttpsRedirection();

//app.UseSwaggerUi3(settings =>
//{
//    settings.Path = "/api";
//    settings.DocumentPath = "/api/specification.json";
//});

app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
//app.UseIdentityServer();
//app.UseAuthorization();
app.MapControllers();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller}/{action=Index}/{id?}");
//    endpoints.MapRazorPages();
//});

app.Run();


#region Methods
//EF Migrations and Seed Database
static async Task UseEFMigrations(WebApplication app)
{
	using var scope = app.Services.CreateScope();
	var services = scope.ServiceProvider;

	try
	{
		var context = services.GetRequiredService<ApplicationDbContext>();

		if (context.Database.IsSqlServer())
		{
			context.Database.Migrate();
		}

		var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
		var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
		await ApplicationDbContextSeed.SeedDefaultUserAsync(userManager, roleManager);

	}
	catch (Exception ex)
	{
		var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
		logger.LogError(ex, "An error occurred while migrating or seeding the database.");
		throw;
	}
}

#endregion
