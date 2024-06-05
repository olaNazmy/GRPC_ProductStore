using Grpc.Net.Client;
using ITI.Grpc.Client.Protos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ITI.Grpc.Client.Protos.InventoryServiceP;

namespace ITI.Grpc.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreProductController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> AddProduct(Product product)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7046");
            var client = new InventoryServicePClient(channel);
            var IsExisted = client.GetProductById(new Id { Id_ = product.Id });
            if (IsExisted.IsExisted_ == false)
            {
                var addedProduct = await client.AddProductAsync(product);
                return Ok(addedProduct);
            }

            var Productedited = await client.UpdateProductAsync(product);
            return Ok(Productedited);
        }
    }
}
