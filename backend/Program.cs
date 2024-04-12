using backend.Application.Repository;
using backend.Application.UseCases.SearchBooksUseCase;
using backend.Application.UseCases.SearchBooksUseCase.Abstractions;
using backend.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});


builder.Services.AddDbContext<BooksDbContext>(options => options.UseInMemoryDatabase("books"));
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<ISearchBooksUseCase, SearchBooksUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost");

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
