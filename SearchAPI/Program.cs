using RestSharp;

var builder = WebApplication.CreateBuilder(args);

var restClient = new RestClient("https://localhost:9001");
restClient.Post(new RestRequest("configuration", Method.Post)
    .AddJsonBody(new
    {
        Url = "http://" + Environment.MachineName,
    }));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(config => config.AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();