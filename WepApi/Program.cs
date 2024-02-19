using Aplicação.Aplicacoes;
using Aplicação.Interfaces;
using Dominio.Interfaces.Genericos;
using Dominio.Interfaces.InterfaceServicos;
using Dominio.Services;
using Dominio;
using Entidades.Entidades;
using InfraEstrtutura.Configuracoes;
using InfraEstrtutura.Repositorios.Genericos;
using InfraEstrtutura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using WepApi.Token;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<Contexto>(options =>
options.UseSqlServer(
                 builder.Configuration.GetConnectionString("DefautConnection"))); 
builder.Services.AddDefaultIdentity<AplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<Contexto>();

// INTERFACE E REPOSITORIO
builder.Services.AddSingleton(typeof(IGenericos<>), typeof(RepositorioGenerico<>));
builder.Services.AddSingleton<INoticia, RepositorioNoticia>();
builder.Services.AddSingleton<IUsuario, RepositorioUsuario>();

// SERVIÇO DOMINIO
builder.Services.AddSingleton<IServicoNoticia, ServicoNoticia>();

// INTERFACE APLICAÇÃO
builder.Services.AddSingleton<IAplicacaoNoticia, AplicacaoNoticia>();
builder.Services.AddSingleton<IAplicacaoUsuario, AplicacaoUsuario>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(option =>
       {
           option.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = false,
               ValidateAudience = false,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,

               ValidIssuer = "Teste.mws",
               ValidAudience = "Teste.mws",
               IssuerSigningKey = JwtSecurity.Create("Secret_Key-123456785kmfdshfdsnfdsnfuisdfsdf")
           };

           option.Events = new JwtBearerEvents
           {
               OnAuthenticationFailed = context =>
               {
                   Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                   return Task.CompletedTask;
               },
               OnTokenValidated = context =>
               {
                   Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                   return Task.CompletedTask;
               }
           };
       });


builder.Services.AddControllers();
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

//// JWT
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//      .AddJwtBearer(option =>
//      {
//          option.TokenValidationParameters = new TokenValidationParameters
//          {
//              ValidateIssuer = false,
//              ValidateAudience = false,
//              ValidateLifetime = true,
//              ValidateIssuerSigningKey = true,

//              ValidIssuer = "Teste.Securiry.Bearer",
//              ValidAudience = "Teste.Securiry.Bearer",
//              IssuerSigningKey = JwtSecurity.Create("Secret_Key-123456785kmfdshfdsnfdsnfuisdfsdf")
//          };

//          option.Events = new JwtBearerEvents
//          {
//              OnAuthenticationFailed = context =>
//              {
//                  Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
//                  return Task.CompletedTask;
//              },
//              OnTokenValidated = context =>
//              {
//                  Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
//                  return Task.CompletedTask;
//              }
//          };
//      });



app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
