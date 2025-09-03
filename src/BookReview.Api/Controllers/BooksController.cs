using Microsoft.AspNetCore.Mvc;
using BookReview.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookReview.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private static readonly List<Book> _books = new();

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks() => _books;

        [HttpPost]
        public ActionResult<Book> AddBook(Book book)
        {
            book.Id = Guid.NewGuid();
            _books.Add(book);
            return CreatedAtAction(nameof(GetBooks), new { id = book.Id }, book);
        }

        [HttpGet("{id}/reviews")]
        public ActionResult<IEnumerable<Review>> GetReviews(Guid id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            return book == null ? NotFound() : book.Reviews;
        }

        [HttpPost("{id}/reviews")]
        public ActionResult<Review> AddReview(Guid id, Review review)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();
            review.Id = Guid.NewGuid();
            book.Reviews.Add(review);
            return review;
        }
    }
}
