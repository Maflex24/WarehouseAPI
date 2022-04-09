using Microsoft.EntityFrameworkCore;
using WarehouseAPI.Entities;
using WarehouseAPI.Models;

namespace WarehouseAPI.Services
{
    public interface IProductService
    {
        public List<ProductModelDto> GetProducts(int resultsAmount, bool isWarehouseQuery, ProductSearchModel searchModel);
    }

    public class ProductService : IProductService
    {
        private readonly WarehouseDbContext _dbContext;

        public ProductService(WarehouseDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<ProductModelDto> GetProducts(int resultsAmount, bool isWarehouseQuery, ProductSearchModel searchModel)
        {
            if (resultsAmount < 1)
                resultsAmount = 1;

            var baseProducts = _dbContext
                .Products
                .Where(p => searchModel.Code == null || p.Code.ToUpper().Contains(searchModel.Code.ToUpper()))
                .Where(p => searchModel.Name == null || p.Name.ToLower().Contains(searchModel.Name.ToLower()))
                .Include(p => p.Sex)
                .Include(p => p.Color)
                .Include(p => p.Size)
                .Include(p => p.Category)
                .Where(p => searchModel.Size == null || p.Size.Name.ToLower() == searchModel.Size.ToLower())
                .Where(p => searchModel.Sex == null || p.Sex.Name.ToLower().Contains(searchModel.Sex.ToLower()))
                .Where(p => searchModel.Color == null || p.Color.Name.ToLower().Contains(searchModel.Color.ToLower()))
                .Where(p => searchModel.Category == null || p.Category.Name.ToLower().Contains(searchModel.Category.ToLower()));


            var products = baseProducts
                .Take(resultsAmount)
                .OrderBy(p => p.Name)
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
