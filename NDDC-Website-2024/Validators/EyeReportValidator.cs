using FluentValidation;
using NddcWebsiteLibrary.Model.IReport;

namespace NDDC_Website_2024.Validators
{
    public class EyeReportValidator : AbstractValidator<MyIReportModel>
    {
        public EyeReportValidator()
        {
            RuleFor(e => e.Type).NotEmpty().WithMessage("The Report Title is Required");
            RuleFor(e => e.Name).NotEmpty().WithMessage("You Must Supply Your Full Name");
            RuleFor(e => e.Email).NotEmpty();
            RuleFor(e => e.Phone).NotEmpty();
            RuleFor(e => e.State).NotEmpty();
            RuleFor(e => e.Location).NotEmpty();
        }
    }
}
