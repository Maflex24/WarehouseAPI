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
                if (!_dbContext.Categories.Any())
                {
                    var categories = GetCategories();
                    _dbContext.Categories.AddRange(categories);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Colors.Any())
                {
                    var colors = GetColors();
                    _dbContext.Colors.AddRange(colors);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Sexes.Any())
                {
                    var sexes = new List<Sex>()
                    {
                        new Sex() {Name = "woman"},
                        new Sex() {Name = "men"},
                        new Sex() {Name = "unisex"}
                    };
                    _dbContext.Sexes.AddRange(sexes);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Sizes.Any())
                {
                    var sizes = new List<Size>()
                    {
                        new Size() {Name = "xxs"},
                        new Size() {Name = "xs"},
                        new Size() {Name = "s"},
                        new Size() {Name = "m"},
                        new Size() {Name = "l"},
                        new Size() {Name = "xl"},
                        new Size() {Name = "xxl"},
                        new Size() {Name = "xxxl"}
                    };
                    _dbContext.Sizes.AddRange(sizes);
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

        private List<Color> GetColors()
        {
            List<string> colors = new List<string>()
            {
                "pink", "red", "orange", "beige", "yellow", "green", "light blue", "dark blue", "purple", "brown",
                "grey", "black", "white"
            };
            List<Color> colorsList = new List<Color>();

            foreach (var color in colors)
            {
                colorsList.Add(
                    new Color()
                    {
                        Name = color
                    });
            }

            return colorsList;
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
                new List<Product>(_generateProducts.GenerateProductsWithAllSizeAndColors("Mini-cute", "skirts", "woman")),
                new List<Product>(_generateProducts.GenerateProductsWithAllSizeAndColors("Bike leather", "jackets", "unisex")),
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
