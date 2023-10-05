using FluentValidation;
using ProfileApp.Dto.TblAppRoleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.ValidationRules
{
    public class TblAppRoleCreateDtoValidator : AbstractValidator<TblAppRoleCreateDto>
    {
        public TblAppRoleCreateDtoValidator()
        {
            RuleFor(x=>x.Defination).NotEmpty();
            
            
        }
    }
}
