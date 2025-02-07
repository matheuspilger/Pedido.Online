using Pedido.Online.Api.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddCors();
builder.Services.RegisterDependencies(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.MapControllers();
await app.RunApp();
