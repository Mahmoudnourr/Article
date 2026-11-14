using Submission.API;
using Submission.API.Endpoints;
using Submission.Application;
using Submission.Persistance;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddPersistanceServices(builder.Configuration);

// swagger 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
#region Use Services

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI().UseRouting();
}
#endregion
app.RegisterEndpoints();


app.Run();
