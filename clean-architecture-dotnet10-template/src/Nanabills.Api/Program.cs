using Nanabills.Application;
using Nanabills.Contracts.Constants;

var builder = WebApplication.CreateBuilder(args);

string mediatorLicenseKey = builder.Configuration.GetValue<string>("MediatorR:LicenseKey")
    ?? throw new InvalidOperationException(ExceptionsMessages.MediatRLicenseKeyMissing);

// Add services to the container.
builder.Services
    .AddApplication(mediatorLicenseKey)
    .AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
