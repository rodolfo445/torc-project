using backend.Infrastructure.EventHandlers;

namespace backend.Application.UseCases.SearchBooksUseCase.Events;

public class SearchBooksEventHandler : IEventHandler<SearchBooksEvent>
{
    private readonly ILogger<SearchBooksEventHandler> _logger;

    public SearchBooksEventHandler(ILogger<SearchBooksEventHandler> logger) => _logger = logger;

    public async Task Handle(SearchBooksEvent @event) =>
    _logger.LogInformation("Received search event. Search filter: {filter}. Total books found: {count}", @event.SearchFilter, @event.BooksCount);
}