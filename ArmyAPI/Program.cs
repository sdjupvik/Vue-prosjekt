using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(setupAction =>
{
    setupAction.AddPolicy("army-ui",
        config =>
        {
            config.WithOrigins("http://localhost:4000").AllowCredentials().AllowAnyHeader().AllowAnyMethod();
        });
});
builder.Services.AddDbContext<ArmyDBContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SQLite")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("army-ui");
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();
