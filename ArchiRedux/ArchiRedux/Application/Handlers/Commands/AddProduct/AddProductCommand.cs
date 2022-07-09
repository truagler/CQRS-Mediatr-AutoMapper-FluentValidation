using ArchiRedux.Domain.Model;
using MediatR;

namespace ArchiRedux.Application.Handlers.Commands.AddProduct
{
    public class AddProductCommand: IRequest<Product>
    {
        public Product Product { get; set; }

        public AddProductCommand(Product product)
        {
            Product = product;
        }
    }
}