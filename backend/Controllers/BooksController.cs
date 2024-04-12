using backend.Application.UseCases.SearchBooksUseCase.Abstractions;
using backend.Application.UseCases.SearchBooksUseCase.Model;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly ILogger<BooksController> _logger;
    private readonly ISearchBooksUseCase _searchBooksUseCase;

    public BooksController(ILogger<BooksController> logger, ISearchBooksUseCase searchBooksUseCase)
    {
        _logger = logger;
        _searchBooksUseCase = searchBooksUseCase;
    }

    [HttpGet(Name = "GetBooks")]
    public async Task<ActionResult> Get([FromQuery] BooksQueryParameters queryParameters)
    {
        var fieldIsValid = Enum.TryParse<FieldName>(queryParameters.FieldName, out var fieldName);

        if (!fieldIsValid)
            return BadRequest();


        var searchFilter = new SearchFilter { Field = fieldName, Value = queryParameters.Value };

        var books = await _searchBooksUseCase.SearchBooksAsync(searchFilter);

        var booksViewModel = books.Select(book => book.ToViewModel());

        return Ok(booksViewModel);
    }
}
