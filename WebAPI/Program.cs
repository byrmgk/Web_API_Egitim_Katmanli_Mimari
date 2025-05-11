using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using Repositories.EfCore;
using Services.Contracts;
using WebAPI.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Nlog ayarlar�n� yap�yoruz.
//TODO: oblolete olay� i�in de�i�iklik yap�yoruz.
//LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
LogManager.Setup().LoadConfigurationFromFile(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

//TODO: ��erik Pazarl��� i�in konfig�rasyon yapaca��z.
builder.Services.AddControllers(config => 
{
    config.RespectBrowserAcceptHeader = true; //TODO: Acceptable olanlar� d�nd�r.
    config.ReturnHttpNotAcceptable = true; //TODO: Bizim kabul edemedi�imiz bir i�erik varsa 406 d�nd�r.
})
    .AddCustomCsvFormatter() //TODO: AddCustomCsvFormatter kullanmak i�in gerekli ayarlar� yap�yoruz.
    .AddXmlDataContractSerializerFormatters() //TODO: XML format�nda d�nd�rmek i�in gerekli ayarlar� yap�yoruz.                                  
    .AddApplicationPart(typeof(Presentation.AssemblyRefence).Assembly)   //TODO:Presentation katman� i�in gerekli olan ayarlar� yap�yoruz.
    .AddNewtonsoftJson(); //TODO: NewtonsoftJson paketini kullanabilmek i�in gerekli ayarlar� yapal�m.

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//TODO: Program.cs kendi yazd���m�z class� ekliyoruz.
//TODO: ServicesExtensions db va�lant�s� ta��nd��� i�in,
builder.Services.ConfigureSqlContext(builder.Configuration);
//TODO: Parametre kullanmad�k. ��nk� ConfigureRepositoryManeger metodu sadece this ald�.
builder.Services.ConfigureRepositoryManeger();
//TODO: ServicesExtensions class�nda tan�mlad���m�z ConfigureServiceManager kullanabilmek i�in ekliyoruz.   
builder.Services.ConfigureServiceManager();
//TODO:ServicesExtensions class�nda tan�mlad���m�z ConfigureLoggerService kullanabilmek i�in ekliyoruz. 
builder.Services.ConfigureLoggerService();
//TODO:AutoMapper ayarlar�n� yap�yoruz.
builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

//TODO: app ne zaman elde ediliyor? Services i�lemleri tamamland�ktan sonra elde ediliyor.
//TODO: app olu�turduk ancak ConfigureExceptionHandler diye metot yazd�k. Buda ILoggerService al�yor. Ne yapaca��z.
//TODO: Bu i�lemi GetRequiredService metodu ile yap�yoruz.
var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);  

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
