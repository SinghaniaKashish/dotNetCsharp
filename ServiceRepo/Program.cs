


//Request --> controller --> service --> Repository --> response

//controller
using ServiceRepo.Models;
using ServiceRepo.Repositories;
using ServiceRepo.Services;

public class Program
{
    static void Main()
    {
        IProductRepository productRepository = new ProductRepository(); 
        IProductServices productServices = new ProductServices(productRepository);

        var res = productServices.GetProductById(1);
        Console.WriteLine(res.Name + "   "+ res.Price);

        var res1 = productServices.GetProductAll();
        foreach (var item in res1)
        {
            Console.WriteLine(item.Name + "  " + item.Price);
        }

        productServices.AddProduct(new Product
        {
            Id = 3,
            Name = "flower",
            Price = 50,
            CreatedDate= DateTime.Now
        });

        

    }
}

