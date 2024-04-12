using backend.Application.Models;
using backend.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace backend.Application.Repository;

public class BookRepository : IBookRepository
{
    private readonly BooksDbContext _context;

    public BookRepository(BooksDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _context.Database.EnsureCreated();
    }

    public async Task<IList<Book>> FindAsync(string field, string value)
    {
        IQueryable<Book> query = _context.Books;

        query = field switch
        {
            "FirstName" => query.Where(book => book.FirstName.Contains(value)),
            "LastName" => query.Where(book => book.LastName.Contains(value)),
            "ISBN" => query.Where(book => book.ISBN.Contains(value)),
            "Title" => query.Where(book => book.Title.Contains(value)),
            _ => Enumerable.Empty<Book>().AsQueryable()
        };

        return await query.ToListAsync();
    }
}