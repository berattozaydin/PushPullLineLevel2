using Blazor.Core.Src;
using BlazorBLL.Managers;
using BlazorBLL.Middleware;
using BlazorBLL.State;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PetaPoco;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();IConfiguration configuration { get; }
var level3DbConnection = builder.Configuration.GetSection("ConnectionString").Get<ConnectionString>();
var dbProviders = builder.Configuration.GetSection("DbProviders").Get<DbProviders>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton(x =>
{
    return new Database(DatabaseConfiguration.Build()
   .UsingConnectionString(ConnectionString.PostGre)
   .UsingProviderName(DbProviders.PostSql)
   .UsingCommandTimeout(180)
   .WithAutoSelect());
}
);
builder.Services.AddScoped<IDatabase>(x =>
{
    return DatabaseConfiguration.Build()
       .UsingConnectionString(ConnectionString.PostGre)
       .UsingProviderName(DbProviders.PostSql)
       .UsingCommandTimeout(180)
       .WithAutoSelect()
       .Create();
});
builder.Services.AddSignalR();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddTransient<Manager>();
builder.Services.AddScoped<CustomerOrderManager>();
builder.Services.AddScoped<AuthManager>();
builder.Services.AddScoped<EvtAlmManager>();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

var key = Encoding.ASCII.GetBytes("qweqewqeqwe123123123qwefdsagagsa");
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };

});

var app = builder.Build();


//app.UseResponseCompression();
// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}*/
app.UseMiddleware<ExceptionMiddleware>();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseCors("MyPolicy");
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); endpoints.MapFallbackToFile("index.html"); });
app.MapRazorPages();
//app.MapControllers();

app.MapHub<Socket>("/websocket");


app.Run();
