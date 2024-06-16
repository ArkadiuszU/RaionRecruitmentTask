using MediatR;
using RaionRecruitmentTaskApplication.Balances.Dtos;
using RaionRecruitmentTaskDomain.Entities;
using RaionRecruitmentTaskDomain.Exceptions;
using RaionRecruitmentTaskDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaionRecruitmentTaskApplication.Balances.Commands.Withdraw
{
    public class WithdrawCommandHandler(IBalanceRepository repository) : IRequestHandler<WithdrawCommand>
    {
        public async Task Handle(WithdrawCommand request, CancellationToken cancellationToken)
        {
            var balance = await repository.GetBalance(request.BalanceId);

            if (balance is null)
                throw new NotFoundException(nameof(Balance), request.BalanceId);

            if (request.WithdrawValue >=  balance.Value)
                throw new WithdrawValueTooHighException($"Withdraw value: {request.WithdrawValue} is too high for balance: {balance.Id}");

            await repository.Withdraw(balance, request.WithdrawValue);
           
        }
    }
}
