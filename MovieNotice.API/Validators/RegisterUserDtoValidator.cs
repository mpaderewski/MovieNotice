using FluentValidation;
using MovieNotice.API.Entities;
using MovieNotice.Common.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNotice.API.Services.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(MovieNoticeDbContext dbContext) 
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).MinimumLength(6);
            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);
            RuleFor(x => x.Email).Custom((value, context) =>
            {
                if(dbContext.User.Any(u => u.Email == value))
                {
                    context.AddFailure("Email", "Istnieje konto z takim mailem");
                }
            }
            );
        }
    }
}
