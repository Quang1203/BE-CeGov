using MISA.CeGov.Web07.GD.NDQuang;
using MISA.CeGov.Web07.GD.NDQuang.API;
using MISA.CeGov.Web07.GD.NDQuang.API.Core;
using MISA.CeGov.Web07.GD.NDQuang.Core;
using MISA.CeGov.Web07.GD.NDQuang.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddScoped<IEmulationTitleService, EmulationTitleService>();
builder.Services.AddScoped<IEmulationTitleRepository, EmulationTitleRepository>();

//builder.Services.AddScoped<IEmulationTitleService, IEmulationTitleRepository>();
//builder.Services.AddScoped<EmulationTitleService, EmulationTitleRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// cho các prop của các bảng bắt đầu viết hoa giống DB
builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.PropertyNamingPolicy = null);

// Lấy dữ liệu connection string từ file appsettings
DatabaseContext.ConnectionString = builder.Configuration.GetConnectionString("MySqlConnection");

var app = builder.Build();

// cấp quyền truy cập cho api
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
