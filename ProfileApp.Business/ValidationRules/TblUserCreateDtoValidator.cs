using FluentValidation;
using ProfileApp.Dto.TblUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.ValidationRules
{
    public class TblUserCreateDtoValidator : AbstractValidator<TblUserCreateDto>
    {
        public TblUserCreateDtoValidator()
        {
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x=>x.Username).NotEmpty();
            RuleFor(x=>x.Password).NotEmpty();
            RuleFor(x=>x.MailAdress).NotEmpty();
        }
    }
}
