using backend.Application.Models;

namespace backend.Application.Repository;

public interface IBookRepository
{
    Task<IList<Book>> FindAsync(string field, string value);
}