using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace backend.Controllers
{
    public class BooksQueryParameters
    {
        [BindRequired]
        public string FieldName { get; set; }

        [BindRequired]
        public string Value { get; set; }
    }
}