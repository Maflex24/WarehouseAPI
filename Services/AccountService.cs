using Microsoft.AspNetCore.Identity;
using WarehouseAPI.Entities;
using WarehouseAPI.Models;

namespace WarehouseAPI.Services
{
    public interface IAccountService
    {
        public void RegisterClient(RegisterClientModelDto clientModel);
    }

    public class AccountService : IAccountService
    {
        private readonly WarehouseDbContext _dbContext;
        private readonly IPasswordHasher<Client> _clientPasswordHasher;

        public AccountService(WarehouseDbContext dbContext, IPasswordHasher<Client> clientPasswordHasher)
        {
            _dbContext = dbContext;
            _clientPasswordHasher = clientPasswordHasher;
        }


        public void RegisterClient(RegisterClientModelDto clientModel)
        {
            var address = new Address()
            {
                HouseNumber = clientModel.HouseNumber,
                ApartmentNumber = clientModel.ApartmentNumber,
                Street = clientModel.Street,
                PostalCode = clientModel.PostalCode,
                Country = clientModel.Country
            };

            var client = new Client()
            {
                Login = clientModel.Login,
                Email = clientModel.Email,
                FirstName = clientModel.FirstName,
                LastName = clientModel.LastName
            };

            client.PasswordHash = _clientPasswordHasher.HashPassword(client, clientModel.Password);

            _dbContext.Addresses.Add(address);
            _dbContext.SaveChanges();

            client.AddressId = _dbContext
                .Addresses
                .Where(a => a == address)
                .Select(a => a.Id)
                .FirstOrDefault();

            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
        }
    }

}
