using AutoMapper;
using MediatR;
using RaionRecruitmentTaskApplication.Balances.Dtos;
using RaionRecruitmentTaskDomain.Entities;
using RaionRecruitmentTaskDomain.Exceptions;
using RaionRecruitmentTaskDomain.Repositories;

namespace RaionRecruitmentTaskApplication.Balances.Queries.GetBalanceStatus
{
    public class GetBalanceStatusQueryHandler (IBalanceRepository balanceRepository,
        IMapper mapper)
        : IRequestHandler<GetBalanceStatusQuery, BalanceDto>
    {
        public async Task<BalanceDto> Handle(GetBalanceStatusQuery request, CancellationToken cancellationToken)
        {
            var balance = await balanceRepository.GetBalance(request.Id);

            if (balance is null) 
                throw new NotFoundException(nameof(Balance), request.Id);
 
            var balanceDto = mapper.Map<BalanceDto>(balance);
            return balanceDto;

            
        }


    }
}
