using Microsoft.OpenApi.Models;
using Polly;
using System.Reflection;
using ViaCep_WebApi.Services.Http;
using ViaCep_WebApi.Services.ViaCep;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do Polly
builder.Services.AddHttpClient<IHttpService, HttpService>()
    .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))));

builder.Services.AddScoped<IViaCepService, ViaCepService>();

// Configura��o dos controladores
builder.Services.AddControllers();

// Configura��o do Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ViaCep API", Version = "v1" });

    // Configura��o para incluir os coment�rios XML no Swagger
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    // Configura��o do Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ViaCep API v1");
    });
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
