using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    public class FluentValidation
    {
        public class BookValidator : AbstractValidator<Book>
        {
            public BookValidator()
            {
                RuleFor(obj => obj.BookId).NotEmpty().GreaterThan(0).WithMessage("Can't Be Negative Or Null");
                RuleFor(obj => obj.BookName).NotEmpty().Matches(@"^[a-zA-Z ]+$").WithMessage("Can Only Contains Alphabets");
                RuleFor(obj => obj.Author).NotEmpty().Matches(@"^[a-zA-Z ]+$").WithMessage("Can Only Contains Alphabets");
                RuleFor(obj => obj.Price).NotEmpty().GreaterThan(0).WithMessage("Can't Be Negative Or Null");
                RuleFor(obj => obj.Category).NotEmpty().Matches(@"^[a-zA-Z]+$").WithMessage("Can Only Contains Alphabets");
            }
        }
    }
}
