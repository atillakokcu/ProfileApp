using FluentValidation;
using ProfileApp.Dto.TblUserAccountDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.ValidationRules
{
    public class TblUserAccountCreateDtoValidator : AbstractValidator<TblUserAccountCreateDto>
    {
        public TblUserAccountCreateDtoValidator()
        {
            RuleFor(x=>x.AccountName).NotEmpty().WithMessage("Account Name field is a required field.");
            RuleFor(x=>x.AccountUrl).NotEmpty().WithMessage("Account Url field is a required field.");
            RuleFor(x=>x.UserId).NotEmpty();
            
        }
    }
}
