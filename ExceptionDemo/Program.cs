using ExceptionDemo.Configs;
using ExceptionDemo.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddExceptionHandler<ExceptionHandler>();


builder.Services.AddConfigServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseExceptionHandler(opt => { });

app.UseAuthorization();

app.MapControllers();

app.Run();
