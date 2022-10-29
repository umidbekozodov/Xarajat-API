using Xarajat_API.Data;
using Xarajat_API.Entities;

public  class ProductServices
{
    public static void Start()
    {
        var prcontext = new ProductDbContext();
        var product = new Product()
        {
            Name = "Olma",
            Category = new Category()
            {
                Name = "1cat"
            }
        };

        prcontext.Add(product);
        prcontext.SaveChanges();

        var newCategory = new Category()
        {
            Name = "name2",
            Products = new List<Product>()
            {
                new Product()
                {
                    Name = "name3"
                },
                new Product()
                {
                    Name = "4"
                }
            }
        };
        prcontext.Add(newCategory);
        prcontext.SaveChanges();

            

        var pror = prcontext.Categories.Select(c => new MyObject{Id = c.Id, Name = c.Name}).ToList();
        var anony = prcontext.Categories.Select(c => new{ Id = c.Id, Name = c.Name }).ToList();
    }

}
