using JobPortalAPI.Data.Context;
using JobPortalAPI.Data.Repository;
using JobPortalAPI.Data.Repository.Interfaces;
using JobPortalAPI.Models;
using JobPortalAPI.Models.Mapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapperProfiles));

builder.Services.AddDbContext<JobPortalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IGenericRepository<CompanyModel>, GenericRepository<CompanyModel>>();
builder.Services.AddScoped<IGenericRepository<ApplicationModel>, GenericRepository<ApplicationModel>>();
builder.Services.AddScoped<IGenericRepository<ApplicationResponseModel>, GenericRepository<ApplicationResponseModel>>();
builder.Services.AddScoped<IGenericRepository<CategoryRequestModel>, GenericRepository<CategoryRequestModel>>();
builder.Services.AddScoped<IGenericRepository<CompanyAddressModel>, GenericRepository<CompanyAddressModel>>();
builder.Services.AddScoped<IGenericRepository<CompanyLoginInfo>, GenericRepository<CompanyLoginInfo>>();
builder.Services.AddScoped<IGenericRepository<JobCategoryModel>, GenericRepository<JobCategoryModel>>();
builder.Services.AddScoped<IGenericRepository<JobsModel>, GenericRepository<JobsModel>>();
builder.Services.AddScoped<IGenericRepository<PersonAddressModel>, GenericRepository<PersonAddressModel>>();
builder.Services.AddScoped<IGenericRepository<PersonLoginInfoModel>, GenericRepository<PersonLoginInfoModel>>();
builder.Services.AddScoped<IGenericRepository<PersonModel>, GenericRepository<PersonModel>>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
