using RestSharp;

var builder = WebApplication.CreateBuilder(args);
/*
var restClient = new RestClient("http://balancer");
restClient.Post(new RestRequest("/ServiceReq", Method.Post)
    .AddJsonBody(new
    {
        Url = "http://" + Environment.MachineName,
    }));
*/

var http = new HttpClient();
http.BaseAddress = new Uri("http://localhost:9001");
Task<string> task = http.PostAsync("/ServiceReg?url" + "http//:" + Environment.MachineName);

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