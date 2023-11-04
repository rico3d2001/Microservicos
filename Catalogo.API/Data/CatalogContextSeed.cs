using Catalogo.API.Entities;
using MongoDB.Driver;

namespace Catalogo.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existiProduct = productCollection.Find( p => true).Any();
            if (!existiProduct)
            {
                productCollection.InsertMany(GetMyProducts());
            }
        }

        private static IEnumerable<Product> GetMyProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "653c2bec9f7fcff418351755",
                    Name = "IPhone X",
                    Description = "IPhone o doido 1",
                    Image = "product1.png",
                    Price = 5000.0M,
                    Category = "Smartphones",
                },
                new Product()
                {
                    Id = "653c2bf29f7fcff418351756",
                    Name = "Samsung 10",
                    Description = "Samsung o doido 2",
                    Image = "product2.png",
                    Price = 2000.0M,
                    Category = "Smartphones",
                },
                new Product()
                {
                    Id = "653c2bf69f7fcff418351757",
                    Name = "Xiaomi",
                    Description = "Xiaomi o doido 3",
                    Image = "product3.png",
                    Price = 1000.0M,
                    Category = "Smartphones",
                }
            };
        }
    }
}
