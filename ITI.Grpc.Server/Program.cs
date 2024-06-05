using ITI.Grpc.Server.Services;

var builder = WebApplication.CreateBuilder(args);

//add grpc service 
builder.Services.AddGrpc();
// Add services to the container.
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
//use it
app.MapGrpcService<InventroyService>();
app.Run();
