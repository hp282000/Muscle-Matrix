using FluentValidation;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System.Text.RegularExpressions;

namespace Muscle_Matrix.Validation
{
    public class User_Validation : AbstractValidator<UserRequestModel>
    {
        public User_Validation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Not Empty Please");
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(x => x.ContactNo).NotEmpty().WithMessage("Contact Number is Required").Must(IsValidPhoneNumber);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Your Password Length Must be 6 + ")
                    .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");

            RuleFor(x => x.DateOfBirth).Must(BeAValidAge).WithMessage("Invalid Date");

        }
        private bool BeAValidAge(DateTime dateTime)
        {
            int currentYear = DateTime.Now.Year;
            int dobYear = dateTime.Year;

            if (dobYear <= currentYear && dobYear > currentYear - 120)
            {
                return true;
            }
            return false;
        }

        private bool IsValidPhoneNumber(long phoneNumber)
        {
            var s = phoneNumber.ToString();

            string pattern = @"^\d{3}\d{3}\d{4}$";
            return Regex.IsMatch(s, pattern);

        }
    }
}
