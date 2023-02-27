using FileService.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var myAllowOrigin = "myAllowOrigin";
builder.Services.AddCors(options => options.AddPolicy(name: myAllowOrigin,
    policy => { policy
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod(); }));
builder.Services.AddTransient<FileManager>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
