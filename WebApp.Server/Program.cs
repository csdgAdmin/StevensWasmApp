using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

/* Add configuration reference for
 * appsettings.json
 */
IConfiguration config = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/* Set values for all authentication related activities
 * This included the properties in the bearer
 * Insist on validation of relevant schema properties.
 */

builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(bearer =>
{
    bearer.TokenValidationParameters = new()
    {
        ValidIssuer = config["JwtSettings:Issuer"],
        ValidateIssuer = true,
        ValidAudience = config["JwtSettings:Audience"],
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true
    };
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapFallbackToFile("index.html");
app.UseAuthorization();

app.MapControllers();

app.Run();
