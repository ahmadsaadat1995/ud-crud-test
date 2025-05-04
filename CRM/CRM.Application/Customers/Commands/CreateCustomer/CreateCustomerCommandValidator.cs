using FluentValidation;

namespace CRM.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("نام باید وارد شود");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("نام خانوادگی باید وارد شود");
            RuleFor(x => x.NationalCode).Length(10).WithMessage("کد ملی باید ۱۰ رقم باشد");
            RuleFor(x => x.PhoneNumber).Length(11).WithMessage("شماره تلفن باید ۱۱ رقم باشد");
            RuleFor(x => x.Email).EmailAddress().WithMessage("فرمت ایمیل صحیح نیست");
        }
    }
}
