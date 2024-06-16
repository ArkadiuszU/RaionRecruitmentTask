using FluentValidation;


namespace RaionRecruitmentTaskApplication.Balances.Commands.Withdraw
{
    public class WithdrawCommandValidator : AbstractValidator<WithdrawCommand>
    {
        public WithdrawCommandValidator()
        {
            RuleFor(dto => dto.BalanceId)
            .NotNull().WithMessage("BalanceId field is required");

            RuleFor(dto => dto.WithdrawValue)
           .GreaterThan(0).WithMessage("Withdraw value has to be greater than 0");
        }
    }
}
