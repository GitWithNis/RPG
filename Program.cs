using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RPG.Data;
using RPG.Services.ArmorService;
using RPG.Services.CharacterService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Db assumes you have your connection string in dotnet user-secrets "Db:ConnectionString"
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration["Db:ConnectionString"]));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMvc();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});


builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IArmorService, ArmorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}

app.UseSwagger();
app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("v1/swagger.json", "My API V1");
    }
);
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.Run();
