using FluentValidation;
using ProfileApp.Dto.TblUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.ValidationRules
{
    public class UserAppLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserAppLoginDtoValidator()
        {
            RuleFor(x=>x.Username).NotEmpty().WithMessage("Username cannot be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("The password cannot be empty");
        }
    }
}
