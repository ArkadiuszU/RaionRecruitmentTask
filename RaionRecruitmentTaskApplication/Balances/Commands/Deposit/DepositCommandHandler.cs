using MediatR;
using RaionRecruitmentTaskApplication.Balances.Commands.Deposit;
using RaionRecruitmentTaskDomain.Entities;
using RaionRecruitmentTaskDomain.Exceptions;
using RaionRecruitmentTaskDomain.Repositories;


namespace RaionRecruitmentTaskApplication.Balances.Commands.Withdraw
{
    public class DepositCommandHandler(IBalanceRepository repository) : IRequestHandler<DepositCommand>
    {
        public async Task Handle(DepositCommand request, CancellationToken cancellationToken)
        {
            var balance = await repository.GetBalance(request.BalanceId);

            if (balance is null)
                throw new NotFoundException(nameof(Balance), request.BalanceId);

            await repository.Deposit(balance, request.DepositValue);
           
        }
    }
}
