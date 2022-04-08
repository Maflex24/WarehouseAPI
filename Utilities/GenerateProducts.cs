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

        private List<string> sizesList = new List<string>() { "xs", "s", "m", "l", "xl", "xxl", "xxxl" };
        private List<string> colorsList = new List<string>() { "black", "dark black", "light black", "grey", "brown", "green", "dark green", "purple", "pink", "white" };

        public List<Product> GenerateProductsWithAllSizeAndColors(string name, string category, string sex)
        {
            List<Product> products = new List<Product>();

            int categoryId = _dbContext
                .Categories
                .Where(c => c.Name == category)
                .Select(c => c.Id)
                .FirstOrDefault();

            foreach (var color in colorsList)
            {
                foreach (var size in sizesList)
                {
                    products.Add(new Product()
                    {
                        Name = name,
                        CategoryId = categoryId,
                        Color = color,
                        Sex = sex,
                        Size = size,
                        Code = $"{category.Substring(0, 2)}{name.Substring(0, 2)}{size}{color.Substring(0, 4)}{generateRandomStringNumber(6)}".ToUpper()
                    });
                }
            }

            return products;
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
