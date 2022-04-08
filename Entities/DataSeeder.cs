using Microsoft.EntityFrameworkCore;
using WarehouseAPI.Utilities;


namespace WarehouseAPI.Entities
{
    public class DataSeeder
    {
        private readonly WarehouseDbContext _dbContext;
        private readonly GenerateProducts _generateProducts;

        public DataSeeder(WarehouseDbContext dbContext, GenerateProducts generateProducts)
        {
            _dbContext = dbContext;
            _generateProducts = generateProducts;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                Console.WriteLine("Data seeder method");
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
            List<List<Product>> productsList = new List<List<Product>>()
            {
                new List<Product>(_generateProducts.GenerateProductsWithAllSizeAndColors("Shika top", "tops", "woman")),
                new List<Product>(_generateProducts.GenerateProductsWithAllSizeAndColors("Vonga dress", "dresses", "woman")),
                new List<Product>(_generateProducts.GenerateProductsWithAllSizeAndColors("Viking coat", "coats", "men")),
                new List<Product>(_generateProducts.GenerateProductsWithAllSizeAndColors("Harley jacket", "jackets", "men")),
                new List<Product>(_generateProducts.GenerateProductsWithAllSizeAndColors("Harley jacket", "jackets", "woman")),
                new List<Product>(_generateProducts.GenerateProductsWithAllSizeAndColors("Old style jeans", "jeans", "men")),
                new List<Product>(_generateProducts.GenerateProductsWithAllSizeAndColors("Old style jeans", "jeans", "woman")),
            };


            List<Product> products = new List<Product>();
            foreach (var list in productsList)
            {
                foreach (var t in list)
                    products.Add(t);
            }


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
