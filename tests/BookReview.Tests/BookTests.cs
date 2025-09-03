using Xunit;
using BookReview.Api.Models;

namespace BookReview.Tests
{
    public class BookTests
    {
        [Fact]
        public void CanAddReview()
        {
            var book = new Book { Title = "DDD", Author = "Eric Evans" };
            book.Reviews.Add(new Review { Reviewer = "Max", Comment = "Super", Rating = 5 });
            Assert.Single(book.Reviews);
        }
    }
}
