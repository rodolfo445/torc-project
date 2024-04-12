using backend.Application.Models;
using backend.Application.Repository;
using backend.Application.UseCases.SearchBooksUseCase.Abstractions;
using backend.Application.UseCases.SearchBooksUseCase.Events;
using backend.Application.UseCases.SearchBooksUseCase.Model;
using backend.Infrastructure.EventHandlers;

namespace backend.Application.UseCases.SearchBooksUseCase;

public class SearchBooksUseCase : ISearchBooksUseCase
{
    private readonly ILogger<SearchBooksUseCase> _logger;
    private readonly IBookRepository _bookRepository;
    private readonly IEventBus _eventBus;


    public SearchBooksUseCase(ILogger<SearchBooksUseCase> logger, IBookRepository bookRepository, IEventBus eventBus)
    {
        _logger = logger;
        _bookRepository = bookRepository;
        _eventBus = eventBus;
    }

    public async Task<IList<Book>> SearchBooksAsync(SearchFilter searchFilter)
    {
        _logger.LogInformation("{name} started. searchFilter:{model}", nameof(SearchBooksUseCase), searchFilter.ToString());

        var books = await _bookRepository.FindAsync(searchFilter.Field.ToString(), searchFilter.Value);

        _logger.LogInformation("{name} completed. Total found {operation}", nameof(SearchBooksUseCase), books.Count);

        _eventBus.Publish(new SearchBooksEvent { SearchFilter = searchFilter, BooksCount = books.Count });

        return books;
    }
}
