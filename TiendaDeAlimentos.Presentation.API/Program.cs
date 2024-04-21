using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using TiendaDeAlimentos.Core.Application.Interfaces.Repositories.Modules.Inventory;
using TiendaDeAlimentos.Core.Application.Interfaces.Repositories.SystemConfig.Login;
using TiendaDeAlimentos.Core.Application.Interfaces.Services.Modules.Inventory;
using TiendaDeAlimentos.Core.Application.Interfaces.Services.SystemConfig.Email;
using TiendaDeAlimentos.Core.Application.Interfaces.Services.SystemConfig.Login;
using TiendaDeAlimentos.Core.Application.Interfaces.Services.SystemConfig.Security;
using TiendaDeAlimentos.Core.Application.Services.Modules.Inventory;
using TiendaDeAlimentos.Core.Application.Services.SystemConfig.Email;
using TiendaDeAlimentos.Core.Application.Services.SystemConfig.Login;
using TiendaDeAlimentos.Core.Application.Services.SystemConfig.Security;
using TiendaDeAlimentos.Infrastructure.Context;
using TiendaDeAlimentos.Infrastructure.Repositories.Modules.Inventory;
using TiendaDeAlimentos.Infrastructure.Repositories.SystemConfig.Login;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Contextos
builder.Services.AddDbContext<TiendaDeAlimentosContext>(opt =>
{
    opt.UseSqlServer("name=DefaultConnection");
});
#endregion

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
        policy.RequireClaim(ClaimTypes.Role, "Admin"));

    options.AddPolicy("UserPolicy", policy =>
        policy.RequireClaim(ClaimTypes.Role, "User"));
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["AuthSettings:Audience"],
        ValidIssuer = builder.Configuration["AuthSettings:Issuer"],
        RequireExpirationTime = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AuthSettings:key"])),

    };
}
);

builder.Services.AddTransient<ITokenServices, TokenServices>();
builder.Services.AddTransient<IEmailServices, EmailServices>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddTransient<IGestionPedidosRepository, GestionPedidosRepository>();
builder.Services.AddTransient<IGestionPedidosServices, GestionPedidosServices>();
builder.Services.AddTransient<IGestionProductosRepository, GestionProductosRepository>();
builder.Services.AddTransient<IGestionProductosServices, GestionProductosServices>();

#region AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//var mapperConfig = new MapperConfiguration(mapperConfig =>
//{
//    mapperConfig.AddProfile(new RolesMappings());
//});
//IMapper mapper = mapperConfig.CreateMapper();
//builder.Services.AddSingleton(mapper);

#endregion

var app = builder.Build();

app.UseCors(x => x
.AllowAnyMethod()
.AllowAnyHeader()
.SetIsOriginAllowed(origin => true) // allow any origin  
.AllowCredentials());



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
