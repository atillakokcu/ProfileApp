using FluentValidation;
using ProfileApp.Dto.TblUserAccountDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.ValidationRules
{
    public class TblUserAccountUpdateDtoValidator : AbstractValidator<TblUserAccountUpdateDto>
    {
        public TblUserAccountUpdateDtoValidator()
        {

            RuleFor(x => x.AccountName).NotEmpty();
            RuleFor(x => x.AccountUrl).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
