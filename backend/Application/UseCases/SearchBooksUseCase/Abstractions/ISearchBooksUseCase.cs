using backend.Application.Models;
using backend.Application.UseCases.SearchBooksUseCase.Model;

namespace backend.Application.UseCases.SearchBooksUseCase.Abstractions
{
    public interface ISearchBooksUseCase
    {
        Task<IList<Book>> SearchBooksAsync(SearchFilter searchFilter);
    }
}