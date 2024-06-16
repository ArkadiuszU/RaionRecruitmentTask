using MediatR;


namespace RaionRecruitmentTaskApplication.Balances.Commands.Withdraw
{
    public class WithdrawCommand :IRequest
    {
        public int? BalanceId { get; set; }
        public decimal WithdrawValue { get; set; }
    }

}
