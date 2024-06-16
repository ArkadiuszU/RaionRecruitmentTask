using Microsoft.EntityFrameworkCore;
using RaionRecruitmentTaskDomain.Entities;
using RaionRecruitmentTaskDomain.Repositories;

namespace RaionRecruitmentTaskInfrastructure.Repositories
{
    internal class BalanceRepository(RaionRecruitmentTaskDbContext dbContext) 
        : IBalanceRepository
    {
        public async Task<Balance?> GetBalance(int? id)
        {
            var balance = await dbContext.Balances.Include(b=> b.Owner).FirstOrDefaultAsync(b => b.Id == id);

            return balance;
        }

        public async Task Deposit(Balance balance, decimal depositValue)
        {
            balance.Value += depositValue;
            await dbContext.SaveChangesAsync();
        }

        public async Task Withdraw(Balance balance, decimal withdrawValue)
        {
  
            balance.Value -= withdrawValue;
            await dbContext.SaveChangesAsync();
             
        }
    }
}
