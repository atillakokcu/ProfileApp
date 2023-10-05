using FluentValidation;
using ProfileApp.Dto.Interfaces;
using ProfileApp.Dto.TblStatusDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.ValidationRules
{
    public class TblStatusCreateDtoValidator : AbstractValidator<TblStatusCreateDto>
    {
        public TblStatusCreateDtoValidator()
        {
            RuleFor(x=>x.StatusName).NotEmpty();
        }
    }
}
