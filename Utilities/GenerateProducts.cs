using System.Text;
using WarehouseAPI.Entities;

namespace WarehouseAPI.Utilities
{
    public interface IGenerateProducts
    {
        public List<Product> GenerateProductsWithAllSizeAndColors(string name, string category, string sex);
    }

    public class GenerateProducts : IGenerateProducts
    {
        private readonly WarehouseDbContext _dbContext;

        public GenerateProducts(WarehouseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //private List<string> sizesList = new List<string>() { "xs", "s", "m", "l", "xl", "xxl", "xxxl" };
        //private List<string> colorsList = new List<string>() { "black", "dark black", "light black", "grey", "brown", "green", "dark green", "purple", "pink", "white" };

        public List<Product> GenerateProductsWithAllSizeAndColors(string name, string category, string sex)
        {
            List<Product> products = new List<Product>();

            int categoryId = _dbContext
                .Categories
                .Where(c => c.Name == category)
                .Select(c => c.Id)
                .FirstOrDefault();

            var colors = _dbContext
                .Colors
                .ToList();

            var sizes = _dbContext
                .Sizes
                .ToList();

            var sexes = _dbContext
                .Sexes
                .ToList();

            var colorsList = _dbContext
                .Colors
                .Select(c => c.Name)
                .ToList();

            var sizesList = _dbContext
                .Sizes
                .Select(s => s.Name)
                .ToList();

            foreach (var color in colorsList)
            {
                foreach (var size in sizesList)
                {
                    products.Add(new Product()
                    {
                        Name = name,
                        CategoryId = categoryId,
                        ColorId = colors
                            .Where(c => c.Name == color)
                            .Select(c => c.Id)
                            .FirstOrDefault(),
                        SexId = sexes
                            .Where(c => c.Name == sex)
                            .Select(c => c.Id)
                            .FirstOrDefault(),
                        SizeId = sizes
                            .Where(c => c.Name == size)
                            .Select(c => c.Id)
                            .FirstOrDefault(),

                        Code = GenerateProductCode(category, name, size, color)
                    });
                }
            }

            return products;
        }

        private string GenerateProductCode(string category, string name, string size, string color)
        {
            StringBuilder codeBuilder = new StringBuilder();

            codeBuilder.Append(category.PadRight(6).Replace(" ", "").Replace("-", "") + "-");
            codeBuilder.Append(name.PadRight(6).Replace(" ", "").Replace("-", "") + "-");
            codeBuilder.Append(size + "-");
            codeBuilder.Append(color.PadRight(6).Replace(" ", "") + "-");
            codeBuilder.Append(generateRandomStringNumber(4));

            return codeBuilder.ToString().ToUpper();
        }

        private string generateRandomStringNumber(int howManycharQty)
        {
            Random random = new Random();
            string output = String.Empty;

            for (int i = 0; i < howManycharQty; i++)
            {
                Thread.Sleep(5);
                var symbol = random.Next(0, 9).ToString();
                output += symbol;
            }

            return output;
        }
    }
}
