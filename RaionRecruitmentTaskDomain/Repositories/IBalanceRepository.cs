
using RaionRecruitmentTaskDomain.Entities;

namespace RaionRecruitmentTaskDomain.Repositories
{
    public interface IBalanceRepository
    {
        Task<Balance?> GetBalance(int? id);
        Task Deposit(Balance balance, decimal depositValue);
        Task Withdraw(Balance balance, decimal withdrawValue);
    }
}
