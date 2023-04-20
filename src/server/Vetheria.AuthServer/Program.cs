using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Quartz;
using System.Configuration;
using Vetheria.AuthServer;
using Vetheria.AuthServer.Database;
using Vetheria.Common;
using static OpenIddict.Abstractions.OpenIddictConstants;

var options = new WebApplicationOptions
{
    WebRootPath = "wwwroot",
    ContentRootPath = Path.GetFullPath(Directory.GetCurrentDirectory()),
    Args = args
};

var builder = WebApplication.CreateBuilder(options);

// Add services to the container.

//builder.Services.AddRazorPages();
//builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IEmailSender, EmailSender>();


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          //builder.WithOrigins("https://localhost:7200", "http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                          builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.AddDbContext<AuthDbContext>(options =>
{
    // Configure the context to use sqlite.
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));

    // Register the entity sets needed by OpenIddict.
    // Note: use the generic overload if you need
    // to replace the default OpenIddict entities.
    options.UseOpenIddict();
});

builder.Services.Configure<IdentityOptions>(q =>
{
    q.ClaimsIdentity.UserNameClaimType = Claims.Name;
    q.ClaimsIdentity.UserIdClaimType = Claims.Subject;
    q.ClaimsIdentity.RoleClaimType = Claims.Role;
    q.ClaimsIdentity.EmailClaimType = Claims.Email;
});

builder.Services.AddIdentity<ApplicationUserEntity, IdentityRole>(q =>
{
    //q.ClaimsIdentity.UserNameClaimType = Claims.Name;
    //q.ClaimsIdentity.UserIdClaimType = Claims.Subject;
    //q.ClaimsIdentity.RoleClaimType = Claims.Role;
    //q.ClaimsIdentity.EmailClaimType = Claims.Email;

    if (builder.Environment.IsDevelopment())
    {
        q.Password.RequireNonAlphanumeric = false;
        q.Password.RequireUppercase = false;
        q.SignIn.RequireConfirmedAccount = true;
        q.User.RequireUniqueEmail = true;
    }
    else
    {
        q.SignIn.RequireConfirmedAccount = true;
        q.User.RequireUniqueEmail = true;
    }
})
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders()
            .AddDefaultUI();

builder.Services.AddQuartz(options =>
{
    options.UseMicrosoftDependencyInjectionJobFactory();
    options.UseSimpleTypeLoader();
    options.UseInMemoryStore();
});

builder.Services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);

builder.Services.AddOpenIddict()
    .AddCore(options =>
    {

        options.UseEntityFrameworkCore()
               .UseDbContext<AuthDbContext>();

        options.UseQuartz();
    })
    .AddServer(options =>
    {
        options.SetAuthorizationEndpointUris("connect/authorize")
                    .SetLogoutEndpointUris("connect/logout")
                    .SetTokenEndpointUris("connect/token")
                    .SetUserinfoEndpointUris("connect/userinfo");

        options.RegisterScopes(Scopes.Email, Scopes.Profile, Scopes.Roles);

        options.AllowAuthorizationCodeFlow().AllowRefreshTokenFlow();

        options.AddDevelopmentEncryptionCertificate().AddDevelopmentSigningCertificate();

        options.UseAspNetCore()
                       .EnableAuthorizationEndpointPassthrough()
                       .EnableLogoutEndpointPassthrough()
                       .EnableStatusCodePagesIntegration()
                       .EnableTokenEndpointPassthrough()
                       .EnableUserinfoEndpointPassthrough()
                       .EnableStatusCodePagesIntegration();

    })

    .AddValidation(options =>
     {
         options.UseLocalServer();
         options.UseAspNetCore();
     });

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddHostedService<BootstrapWorker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapFallbackToFile("index.html");


app.Run();
