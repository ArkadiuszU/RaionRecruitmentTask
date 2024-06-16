using MediatR;
using RaionRecruitmentTaskApplication.Balances.Dtos;



namespace RaionRecruitmentTaskApplication.Balances.Queries.GetBalanceStatus
{
    public class GetBalanceStatusQuery : IRequest<BalanceDto>
    {
        public int Id { get; set; }
        public GetBalanceStatusQuery(int id)
        {
            Id = id;
        }
    }
}
