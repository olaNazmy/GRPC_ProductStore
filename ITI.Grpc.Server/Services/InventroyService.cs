using Grpc.Core;
using ITI.Grpc.Server.Protos;
using static ITI.Grpc.Server.Protos.InventoryServiceP;

namespace ITI.Grpc.Server.Services
{
    public class InventroyService : InventoryServicePBase
    {
        public List<Product> Products = new List<Product>()
        {
            new Product{Id=1,Name="Watch",Price=5000,Description="hellloooooonhvghc" },
            new Product{Id=2,Name="IPad",Price=300,Description="helllooooojbhjhgvgo" },
            new Product{Id=3,Name="TV",Price=4000,Description="helllooooookkhkjghjg" },
        };

        public override async Task<IsExisted> GetProductById(Id request, ServerCallContext context)
        {
            var product = Products.FirstOrDefault(i => i.Id == request.Id_);
            if (product != null)
            {
                return await Task.FromResult(new IsExisted
                {
                    IsExisted_ = true
                }); ;
            }
            return await Task.FromResult(new IsExisted
            {
                IsExisted_ = false
            }); ;
            //return base.GetProductById(request, context);
        }

        public override async Task<Product> AddProduct(Product request, ServerCallContext context)
        {
            Products.Add(request);
            return await Task.FromResult(request);

        }
        public override async Task<Product> UpdateProduct(Product request, ServerCallContext context)

        {
            var product = Products.FirstOrDefault(i => i.Id == request.Id);
            if (product != null)
            {
                product.Name = request.Name;
                product.Price = request.Price;
                product.Description = request.Description;
            }

            return await Task.FromResult(product);
        }

    }
}
