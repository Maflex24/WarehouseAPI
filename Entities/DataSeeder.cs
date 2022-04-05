using Microsoft.EntityFrameworkCore;

namespace WarehouseAPI.Entities
{
    public class DataSeeder
    {
        private readonly WarehouseDbContext _dbContext;

        public DataSeeder(WarehouseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Categories.Any())
                {
                    var categories = GetCategories();
                    _dbContext.Categories.AddRange(categories);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Products.Any())
                {
                    var products = GetProducts();
                    _dbContext.Products.AddRange(products);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    Name = "Smart-Top",
                    CategoryId = _dbContext
                        .Categories
                        .Where(c => c.Name == "tops")
                        .Select(p => p.Id)
                        .FirstOrDefault(),
                    Color = "red",
                    Sex = "woman",
                    Size = "xs",
                    Code = "112233"
                },
                new Product()
                {
                    Name = "Snow Cover",
                    CategoryId = _dbContext
                        .Categories
                        .Where(c => c.Name == "coats")
                        .Select(p => p.Id)
                        .FirstOrDefault(),
                    Color = "black",
                    Sex = "men",
                    Size = "xl",
                    Code = "1133556"
                },
            };

            return products;
        }

        private List<Category> GetCategories()
        {
            var categories = new List<Category>()
            {
                new Category() {Name = "tops"},
                new Category() {Name = "dresses"},
                new Category() {Name = "coats"},
                new Category() {Name = "jackets"},
                new Category() {Name = "trousers"},
                new Category() {Name = "jeans"},
                new Category() {Name = "skirts"}
            };

            return categories;
        }
    }
}
