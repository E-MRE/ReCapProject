using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).NotNull().NotEmpty();
            RuleFor(u => u.FirstName).NotNull().NotEmpty();
            RuleFor(u => u.LastName).NotNull().NotEmpty();
            RuleFor(u => u.Password).NotNull().NotEmpty();
        }
    }
}
