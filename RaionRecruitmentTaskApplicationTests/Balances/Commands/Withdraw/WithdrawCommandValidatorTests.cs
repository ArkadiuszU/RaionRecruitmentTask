using Xunit;
using FluentValidation.TestHelper;

namespace RaionRecruitmentTaskApplication.Balances.Commands.Withdraw.Tests
{
    public class WithdrawCommandValidatorTests
    {
        //TestMethod_Scenario_ExpectResult

        [Fact()]

        public void WithdrawCommand_ForValidCommand_ShouldNotHaveValidationErrors()
        {
            // arrange

            var withdrawCommand = new WithdrawCommand()
            {
                BalanceId = 1,
                WithdrawValue = 12.2m
            };
            var validator = new WithdrawCommandValidator();

            // act
            var result = validator.TestValidate(withdrawCommand);

            // assert

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact()]

        public void WithdrawCommand_ForInvalidCommand_ShouldHaveValidationErrors()
        {
            // arrange

            var withdrawCommand = new WithdrawCommand()
            {
                WithdrawValue = -1
            };
            var validator = new WithdrawCommandValidator();

            // act
            var result = validator.TestValidate(withdrawCommand);

            // assert

            result.ShouldHaveValidationErrorFor(c => c.BalanceId);
            result.ShouldHaveValidationErrorFor(c => c.WithdrawValue);
        }

        [Theory()]
        [InlineData(1)]
        [InlineData(12.4)]
        [InlineData(123)]

        public void Validator_ForValidWithdrawValue_ShouldNotHaveValidationErrors(int withdrawValue)
        {
            // arrange

            var withdrawCommand = new WithdrawCommand()
            {
                BalanceId = 1,
                WithdrawValue = withdrawValue
            };
            var validator = new WithdrawCommandValidator();

            // act
            var result = validator.TestValidate(withdrawCommand);

            // assert

            result.ShouldNotHaveValidationErrorFor(c => c.WithdrawValue);
        }

        [Theory()]
        [InlineData(-1)]
        [InlineData(-12.4)]
        [InlineData(0)]

        public void Validator_ForInvalidWithdrawValue_ShouldHaveValidationErrors(int withdrawValue)
        {
            // arrange

            var withdrawCommand = new WithdrawCommand()
            {
                BalanceId = 1,
                WithdrawValue = withdrawValue
            };
            var validator = new WithdrawCommandValidator();

            // act
            var result = validator.TestValidate(withdrawCommand);

            // assert

            result.ShouldHaveValidationErrorFor(c => c.WithdrawValue);
        }
    
}
}

