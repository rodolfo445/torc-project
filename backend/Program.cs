using backend.Application.Repository;
using backend.Application.UseCases.SearchBooksUseCase;
using backend.Application.UseCases.SearchBooksUseCase.Abstractions;
using backend.Application.UseCases.SearchBooksUseCase.Events;
using backend.Infrastructure;
using backend.Infrastructure.EventHandlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
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

// repository
builder.Services.AddTransient<IBookRepository, BookRepository>();

// usecase
builder.Services.AddTransient<ISearchBooksUseCase, SearchBooksUseCase>();

// event-handlers
builder.Services.AddSingleton<SearchBooksEventHandler>();
builder.Services.AddSingleton<IEventBus, InMemoryEventBus>();

var app = builder.Build();

var eventBus = app.Services.GetRequiredService<IEventBus>();
var eventHandler = app.Services.GetRequiredService<SearchBooksEventHandler>();
eventBus.Subscribe<SearchBooksEvent, SearchBooksEventHandler>(eventHandler);


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
