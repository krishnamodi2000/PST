using EcommAppBLL.Repository.CartProduct;
using EcommAppBLL.Repository.Carts;
using EcommAppBLL.Repository.Category;
using EcommAppBLL.Repository.Comments;
using EcommAppBLL.Repository.Orders;
using EcommAppBLL.Repository.Products;
using EcommAppBLL.Repository.ProductSpecification;
using EcommAppBLL.Repository.Specification;
using EcommAppBLL.Repository.Users;
using EcommAppDAL.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.File("../logs/webapi-.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartProductRepository, CartProductRepository>();
builder.Services.AddScoped<IProductSpecificationRepository, ProductSpecificationRepository>();
builder.Services.AddScoped<ISpecificationRepository, SpecificationsRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IOrderRepository, OrderRepository > ();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(options =>
{
options.UseSqlServer(builder.Configuration.GetConnectionString("ConnString"));
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

//app.UseAuthorization();

app.MapControllers();

app.Run();
