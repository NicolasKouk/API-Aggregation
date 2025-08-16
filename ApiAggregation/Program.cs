var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.MapGet("/", () => { return "Hello Woooorld!"; });
app.MapGet("/services", () => { return "here we have the services!"; });

app.Run();

