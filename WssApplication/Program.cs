using Microsoft.EntityFrameworkCore;
using WssApplication.Api.Extensions;
using WssApplication.Api.Hubs;
using WssApplication.Infrastructure.Db;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// регистрируем сигналР, чтоб взаимодействовать в реал-тайм
builder.Services.AddSignalR();
// регистрируем все наши сервисы
builder.Services.AddServices();
// регистрируем ДБ контекст
builder.Services.AddDbContext<PgContext>((options) => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// регистрируем автомапер
builder.Services
    .AddAutoMapper(typeof(PgContext).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseDefaultFiles();
app.UseStaticFiles();

// энд поинт для работы со справочником, к которому подключаются все пользователи
app.MapHub<CatalogHub>("/catalog");

app.Run();
