using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Security.Claims;
using Vite.AspNetCore;
using WeChooz.TechAssessment.Web.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using WeChooz.TechAssessment.Web.Data;
using Microsoft.EntityFrameworkCore;
using WeChooz.TechAssessment.Web.Data;


var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

var sqlServerConnectionString = builder.Configuration.GetConnectionString("formation") ?? throw new InvalidOperationException("Connection string 'formation' not found.");
var redisConnectionString = builder.Configuration.GetConnectionString("cache") ?? throw new InvalidOperationException("Connection string 'cache' not found.");

builder.Services.AddControllersWithViews();
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.ViewLocationFormats.Add("/{1}/_Views/{0}" + RazorViewEngine.ViewExtension);
});

builder.Services.AddAuthentication("Cookies").AddCookie("Cookies",
    options =>
    {
        options.LoginPath = "/login";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("FormationOnly", p => p.RequireRole("formation"));
    options.AddPolicy("SalesOnly", p => p.RequireRole("sales"));
    options.AddPolicy("FormationOrSales", p => p.RequireRole("formation", "sales"));
});

builder.Services.AddViteServices(options =>
{
    options.Server.Port = 5180;
    options.Server.Https = true;
    options.Server.AutoRun = true;
    options.Server.UseReactRefresh = true;
    options.Manifest = "vite.manifest.json";
});

builder.Services.AddDbContext<TechAssessmentDbContext>(options =>
    options.UseSqlServer(sqlServerConnectionString));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TechAssessmentDbContext>();
}


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.UseRouting();
app.MapDefaultEndpoints();

app.MapPost(
    "/login", async (HttpContext context, PerformLoginRequest request) =>
    {
        if (request.Login != "formation" && request.Login != "sales")
            return Results.Unauthorized();

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, request.Login),
            new Claim(ClaimTypes.Role, request.Login)
        };

        var identity = new ClaimsIdentity(claims, "Cookies");
        var principal = new ClaimsPrincipal(identity);

        await context.SignInAsync("Cookies", principal);

        return Results.Ok();
    }
);
app.MapGet("/formations", () => Results.Redirect("/_api/formations"));
app.MapGet("/create-cours", () => Results.Redirect("/_api/create/cours"));
app.MapGet("/create-session", () => Results.Redirect("/_api/create/session"));
app.MapGet("/create-participant", () => Results.Redirect("/_api/create/participant"));

app.MapControllers();

app.MapControllerRoute(
        name: "fallback_admin",
        pattern: "admin/{*subpath}",
        constraints: new { subpath = @"^(?!swagger).*$" },
        defaults: new { controller = "Admin", action = "Handle" }
);
app.MapControllerRoute(
        name: "fallback_admin_root",
        pattern: "admin/",
        defaults: new { controller = "Admin", action = "Handle" }
    );
app.MapControllerRoute(
        name: "fallback_home",
        pattern: "{*subpath}",
        constraints: new { subpath = @"^(?!swagger).*$" },
        defaults: new { controller = "Home", action = "Handle" }
);
app.MapControllerRoute(
        name: "fallback_home_root",
        pattern: "/",
        defaults: new { controller = "Home", action = "Handle" }
    );

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseWebSockets();
    app.UseViteDevelopmentServer(true);
}

app.Run();
