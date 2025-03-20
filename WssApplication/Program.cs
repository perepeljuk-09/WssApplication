using Microsoft.EntityFrameworkCore;
using WssApplication.Api.Extensions;
using WssApplication.Api.Hubs;
using WssApplication.Infrastructure.Db;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ������������ �������, ���� ����������������� � ����-����
builder.Services.AddSignalR();
// ������������ ��� ���� �������
builder.Services.AddServices();
// ������������ �� ��������
builder.Services.AddDbContext<PgContext>((options) => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// ������������ ���������
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

// ��� ����� ��� ������ �� ������������, � �������� ������������ ��� ������������
app.MapHub<CatalogHub>("/catalog");

app.Run();
