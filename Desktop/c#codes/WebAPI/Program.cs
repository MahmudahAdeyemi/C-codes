using System.Net;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.bin;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme
)
.AddCookie(
option =>
{
    option.Cookie.Name = "ticketsession";
    option.Events = new CookieAuthenticationEvents
    {
        // OnRedirectToLogin = context =>
        // {
        //     // context.Response.StatusCode = (int)HttpStatusCode.
            
        // }
        
    };
}

);
builder.Services.AddScoped<PostService>();
// builder.Services.AddSession(
//     option =>
//     {
//         option.Cookie.Name = "ticketsession";
//         option.Cookie.Expiration = TimeSpan.FromSeconds(5);
//     }
// );

// Add services to the container.
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

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();



app.Run();

