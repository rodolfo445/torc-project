namespace backend.ViewModels;

public record BookViewModel(
    string Title,
    string Name,
    string Copies,
    string Type,
    string ISBN,
    string Category
);