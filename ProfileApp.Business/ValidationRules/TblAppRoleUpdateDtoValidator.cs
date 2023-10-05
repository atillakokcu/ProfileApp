using FluentValidation;
using ProfileApp.Dto.TblAppRoleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.ValidationRules
{
    public class TblAppRoleUpdateDtoValidator : AbstractValidator<TblAppRoleUpdateDto>
    {
        public TblAppRoleUpdateDtoValidator()
        {
            RuleFor(x => x.Defination).NotEmpty();
        }
    }
}
