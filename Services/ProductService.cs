using Microsoft.EntityFrameworkCore;
using WarehouseAPI.Entities;
using WarehouseAPI.Models;

namespace WarehouseAPI.Services
{
    public interface IProductService
    {
        public List<ProductModelDto> GetProducts(int resultsAmount, bool isWarehouseQuery);
    }

    public class ProductService : IProductService
    {
        private readonly WarehouseDbContext _dbContext;

        public ProductService(WarehouseDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<ProductModelDto> GetProducts(int resultsAmount, bool isWarehouseQuery)
        {
            if (resultsAmount < 1)
                resultsAmount = 1;

            var products = _dbContext
                .Products
                .Include(p => p.Sex)
                .Include(p => p.Color)
                .Include(p => p.Size)
                .Include(p => p.Category)
                .Take(resultsAmount)
                .ToList();

            var clientDtos = new List<ProductModelDto>();
            foreach (var product in products)
            {
                clientDtos.Add(new ProductModelDto()
                {
                    Name = product.Name,
                    Category = product.Category.Name,
                    Size = product.Size.Name,
                    Color = product.Color.Name,
                    Sex = product.Sex.Name,
                    Code = GetProductCode(product.Code, isWarehouseQuery) // is null if shouldn't be public
                });
            }

            return clientDtos;
        }

        private string? GetProductCode(string productCode, bool isWarehouseQuery)
        {
            if (isWarehouseQuery)
                return productCode;

            return null;
        }
    }

}
