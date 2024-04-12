using backend.Application.UseCases.SearchBooksUseCase.Model;

namespace backend.Application.UseCases.SearchBooksUseCase.Events;

public class SearchBooksEvent
{
    public SearchFilter SearchFilter { get; set; }
    public int BooksCount { get; set; }
}