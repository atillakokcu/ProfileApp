using FluentValidation;
using ProfileApp.Dto.TblActivationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.ValidationRules
{
    public class TblActivationCreateDtoValidator : AbstractValidator<TblActivationCreateDto>
    {
        public TblActivationCreateDtoValidator()
        {
            RuleFor(x=>x.ActivationCode).NotEmpty();
            RuleFor(x=>x.StatusId).NotEmpty();

        }
    }
}
