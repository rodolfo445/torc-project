namespace backend.Application.UseCases.SearchBooksUseCase.Model;

public record SearchFilter
{
    public required FieldName Field { get; set; }
    public required string Value { get; set; }
}