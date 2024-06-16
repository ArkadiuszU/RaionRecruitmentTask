using FluentValidation;


namespace RaionRecruitmentTaskApplication.Balances.Commands.Deposit
{
    public class DepositCommandValidator : AbstractValidator<DepositCommand>
    {
        public DepositCommandValidator()
        {
            RuleFor(dto => dto.BalanceId)
            .NotNull().WithMessage("BalanceId field is required");
            
            RuleFor(dto => dto.DepositValue)
           .GreaterThan(0).WithMessage("Deposit value has to be greater than 0");
        }
    }
}
