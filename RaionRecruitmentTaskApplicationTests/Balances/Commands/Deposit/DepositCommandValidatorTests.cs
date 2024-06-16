using Xunit;
using FluentValidation.TestHelper;

namespace RaionRecruitmentTaskApplication.Balances.Commands.Deposit.Tests
{
    public class DepositCommandValidatorTests
    {
        //TestMethod_Scenario_ExpectResult

        [Fact()]
        
        public void DepositCommand_ForValidCommand_ShouldNotHaveValidationErrors()
        {
        // arrange
        
            var depositCommand = new DepositCommand()
            {
                BalanceId = 1,
                DepositValue = 12.2m
            };
            var validator = new DepositCommandValidator();

        // act
            var result = validator.TestValidate(depositCommand);

            // assert

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact()]

        public void DepositCommand_ForInvalidCommand_ShouldHaveValidationErrors()
        {
            // arrange

            var depositCommand = new DepositCommand()
            {
                DepositValue = -1
            };
            var validator = new DepositCommandValidator();

            // act
            var result = validator.TestValidate(depositCommand);

            // assert

            result.ShouldHaveValidationErrorFor(c => c.BalanceId);
            result.ShouldHaveValidationErrorFor(c => c.DepositValue);
        }

        [Theory()]
        [InlineData(1)]
        [InlineData(12.4)]
        [InlineData(123)]

        public void Validator_ForValidDepositValue_ShouldNotHaveValidationErrors(int depositValue)
        {
            // arrange

            var depositCommand = new DepositCommand()
            {
                BalanceId = 1,
                DepositValue = depositValue
            };
            var validator = new DepositCommandValidator();

            // act
            var result = validator.TestValidate(depositCommand);

            // assert

            result.ShouldNotHaveValidationErrorFor(c => c.DepositValue);
        }

        [Theory()]
        [InlineData(-1)]
        [InlineData(-12.4)]
        [InlineData(0)]

        public void Validator_ForInvalidDepositValue_ShouldHaveValidationErrors(int depositValue)
        {
            // arrange

            var depositCommand = new DepositCommand()
            {
                BalanceId = 1,
                DepositValue = depositValue
            };
            var validator = new DepositCommandValidator();

            // act
            var result = validator.TestValidate(depositCommand);

            // assert

            result.ShouldHaveValidationErrorFor(c => c.DepositValue);
        }
    }
}