using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using Repositories.EfCore;
using Services.Contracts;
using WebAPI.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Nlog ayarlarýný yapýyoruz.
//TODO: oblolete olayý için deðiþiklik yapýyoruz.
//LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
LogManager.Setup().LoadConfigurationFromFile(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

//TODO: Ýçerik Pazarlýðý için konfigürasyon yapacaðýz.
builder.Services.AddControllers(config => 
{
    config.RespectBrowserAcceptHeader = true; //TODO: Acceptable olanlarý döndür.
    config.ReturnHttpNotAcceptable = true; //TODO: Bizim kabul edemediðimiz bir içerik varsa 406 döndür.
})
    .AddCustomCsvFormatter() //TODO: AddCustomCsvFormatter kullanmak için gerekli ayarlarý yapýyoruz.
    .AddXmlDataContractSerializerFormatters() //TODO: XML formatýnda döndürmek için gerekli ayarlarý yapýyoruz.                                  
    .AddApplicationPart(typeof(Presentation.AssemblyRefence).Assembly)   //TODO:Presentation katmaný için gerekli olan ayarlarý yapýyoruz.
    .AddNewtonsoftJson(); //TODO: NewtonsoftJson paketini kullanabilmek için gerekli ayarlarý yapalým.

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//TODO: Program.cs kendi yazdýðýmýz classý ekliyoruz.
//TODO: ServicesExtensions db vaðlantýsý taþýndýðý için,
builder.Services.ConfigureSqlContext(builder.Configuration);
//TODO: Parametre kullanmadýk. Çünkü ConfigureRepositoryManeger metodu sadece this aldý.
builder.Services.ConfigureRepositoryManeger();
//TODO: ServicesExtensions classýnda tanýmladýðýmýz ConfigureServiceManager kullanabilmek için ekliyoruz.   
builder.Services.ConfigureServiceManager();
//TODO:ServicesExtensions classýnda tanýmladýðýmýz ConfigureLoggerService kullanabilmek için ekliyoruz. 
builder.Services.ConfigureLoggerService();
//TODO:AutoMapper ayarlarýný yapýyoruz.
builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

//TODO: app ne zaman elde ediliyor? Services iþlemleri tamamlandýktan sonra elde ediliyor.
//TODO: app oluþturduk ancak ConfigureExceptionHandler diye metot yazdýk. Buda ILoggerService alýyor. Ne yapacaðýz.
//TODO: Bu iþlemi GetRequiredService metodu ile yapýyoruz.
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
