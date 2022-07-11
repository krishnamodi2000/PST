using LMS.Context;
using LMS.Services.AuthorService;
using LMS.Services.BookService;
using LMS.Services.IssueService;
using LMS.Services.MemberDesignationService;
using LMS.Services.MemberService;
using LMS.Services.PublicationService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibraryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EFConnection"));
});
builder.Services.AddScoped<IBookServices, BookServices>();  //dependency injection for Books
builder.Services.AddScoped<IAuthorServices, AuthorServices>();  //dependency injection for Authors
builder.Services.AddScoped<IPublicationServices, PublicationServices>(); //dependency injection for Publications
builder.Services.AddScoped<IMemberDesignationServices, MemberDesignationServices>();
builder.Services.AddScoped<IMemberServices, MemberServices>();
builder.Services.AddScoped<IIssueServices, IssueServices>();
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
