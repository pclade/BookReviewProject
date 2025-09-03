using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;
using BookReview.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookReview.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _http;
        public List<Book> Books { get; set; } = new();

        public IndexModel(IHttpClientFactory httpFactory)
        {
            _http = httpFactory.CreateClient("api");
        }

        public async Task OnGet()
        {
            Books = await _http.GetFromJsonAsync<List<Book>>("api/books") ?? new();
        }

        public async Task<IActionResult> OnPostAddBook(string Title, string Author)
        {
            var newBook = new Book { Title = Title, Author = Author };
            await _http.PostAsJsonAsync("api/books", newBook);
            return RedirectToPage();
        }
    }
}
