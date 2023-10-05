using FluentValidation;
using ProfileApp.Dto.TblStatusDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.ValidationRules
{
    public class TblStatusUpdateDtoValidator : AbstractValidator<TblStatusUpdateDto>
    {
        public TblStatusUpdateDtoValidator()
        {
            RuleFor(x => x.StatusName).NotEmpty();
        }
    }
}
