using System;
using System.Collections.Generic;

namespace BookReview.Api.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public List<Review> Reviews { get; set; } = new();
    }
}
