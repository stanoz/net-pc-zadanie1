using AutoMapper;
using Microsoft.EntityFrameworkCore;
using zadanie1Backend;
using zadanie1Backend.Data;
using zadanie1Backend.Services;
using zadanie1Backend.Validator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173", "https://localhost:44373")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<Profile, AutoMapperProfile>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
builder.Services.AddScoped<IValidate, Validator>();
builder.Services.AddControllersWithViews();



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseRouting();

app.UseCors("MyAllowSpecificOrigins");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();