using ClientDataCapture_API.Data;
using ClientDataCapture_API.Services;
using SQLitePCL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Batteries.Init();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddCors(options => options.AddPolicy(name: "EventOrigins", policy =>
{
    policy.WithOrigins("https://localhost:7061", "http://localhost:5222", "http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));


builder.Services.AddSingleton<ClientRepository>(new ClientRepository(connectionString));
builder.Services.AddSingleton<AddressRepository>(new AddressRepository(connectionString));
builder.Services.AddSingleton<ContactInfoRepository>(new ContactInfoRepository(connectionString));

builder.Services.AddSingleton<ClientService>();
builder.Services.AddSingleton<AddressService>();
builder.Services.AddSingleton<ContactInfoService>();

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

app.UseCors("EventOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
