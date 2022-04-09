using WarehouseAPI.Entities;

namespace WarehouseAPI.Services
{
    public interface IAccountService
    {
        public void Test();
    }

    public class AccountService : IAccountService
    {
        private readonly WarehouseDbContext _dbContext;

        public AccountService(WarehouseDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Test()
        {
            Console.WriteLine("Account service working");
        }
    }

}
