namespace XTLAB
{
    public class ProductListService
    {
        public List<Product> Products { get; set; } = new List<Product>()
        {
            new Product() { Name = "SP1", Description = "Mo ta cho SP 1", Price = 900},
            new Product() { Name = "SP2", Description = "Mo ta cho SP 2", Price = 100},
            new Product() { Name = "SP3", Description = "Mo ta cho SP 3", Price = 400},
            new Product() { Name = "SP4", Description = "Mo ta cho SP 4", Price = 200},
        };
    }
}