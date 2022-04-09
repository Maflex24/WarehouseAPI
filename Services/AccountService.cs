using Microsoft.AspNetCore.Identity;
using WarehouseAPI.Entities;
using WarehouseAPI.Exceptions;
using WarehouseAPI.Models;

namespace WarehouseAPI.Services
{
    public interface IAccountService
    {
        public void RegisterClient(RegisterClientModelDto clientModel);
        public void RegisterEmployee(RegisterEmployeeModelDto employeeModel);
    }

    public class AccountService : IAccountService
    {
        private readonly WarehouseDbContext _dbContext;
        private readonly IPasswordHasher<Client> _clientPasswordHasher;
        private readonly IPasswordHasher<Employee> _employeePasswordHasher;

        public AccountService(WarehouseDbContext dbContext, IPasswordHasher<Client> clientPasswordHasher, IPasswordHasher<Employee> employeePasswordHasher)
        {
            _dbContext = dbContext;
            _clientPasswordHasher = clientPasswordHasher;
            _employeePasswordHasher = employeePasswordHasher;
        }


        public void RegisterClient(RegisterClientModelDto clientModel)
        {
            bool isMailInDatabase = _dbContext
                .Clients
                .Any(c => c.Email == clientModel.Email);

            if (isMailInDatabase)
                throw new AlreadyExistException("This user already exist");

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

        public void RegisterEmployee(RegisterEmployeeModelDto employeeModel)
        {
            if (_dbContext.Employees.Any(e => e.Login == employeeModel.Login
                                              || _dbContext.Employees.Any(e =>
                                                  e.BadgeNumber == employeeModel.BadgeNumber)))
                throw new AlreadyExistException("Employee with this login or badge number already exist");


            var employee = new Employee()
            {
                BadgeNumber = employeeModel.BadgeNumber,
                FirstName = employeeModel.FirstName,
                LastName = employeeModel.LastName,
                Login = employeeModel.Login,
                PhoneNumber = employeeModel.PhoneNumber
            };

            employee.PasswordHash = _employeePasswordHasher.HashPassword(employee, employeeModel.Password);

            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
        }
    }

}
