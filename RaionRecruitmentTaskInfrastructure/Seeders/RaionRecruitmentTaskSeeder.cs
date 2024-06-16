
using RaionRecruitmentTaskDomain.Entities;

namespace RaionRecruitmentTaskInfrastructure.Seeders
{
    internal class RaionRecruitmentTaskSeeder(RaionRecruitmentTaskDbContext dbContext) : IRaionRecruitmentTaskSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Balances.Any())
                {
                    var balances = GetBalances();
                    dbContext.Balances.AddRange(balances);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<Balance> GetBalances()
        {
            List<Balance> balances = [
                new Balance(){
                    Owner = new AccountOwner(){ Name = "Jan", Surname = "Kowalski" },
                    Value = 2500.53m },
                new Balance(){
                    Owner = new AccountOwner(){ Name = "Piotr", Surname = "Nowak" },
                    Value = 200.84m },
            ];

            return balances;
        }
    }
}
