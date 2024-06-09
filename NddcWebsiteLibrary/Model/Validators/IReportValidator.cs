using FluentValidation;
using NddcWebsiteLibrary.Model.IReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcWebsiteLibrary.Model.Validators
{
    public class IReportValidator : AbstractValidator<MyIReportModel>
    {
        public IReportValidator()
        {
            RuleFor(e => e.Type).NotEmpty().WithMessage("The Report Title is Required"); 
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e.Email).NotEmpty();
            RuleFor(e => e.Phone).NotEmpty();
            RuleFor(e => e.State).NotEmpty();
            RuleFor(e => e.Location).NotEmpty();
        }
    }
}
