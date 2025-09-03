using System;

namespace BookReview.Api.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public string Reviewer { get; set; } = "";
        public string Comment { get; set; } = "";
        public int Rating { get; set; }
    }
}
