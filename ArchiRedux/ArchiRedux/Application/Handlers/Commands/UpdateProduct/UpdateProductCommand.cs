using ArchiRedux.Domain.Model;
using MediatR;

namespace ArchiRedux.Application.Handlers.Commands.UpdateProduct
{
    public class UpdateProductCommand: IRequest<Product>
    {
        public Product Product { get; set; }

        public UpdateProductCommand(Product product)
        {
            Product = product;
        }
    }
}