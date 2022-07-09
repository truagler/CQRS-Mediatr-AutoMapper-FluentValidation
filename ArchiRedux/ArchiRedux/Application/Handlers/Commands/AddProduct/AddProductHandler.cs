using System.Threading;
using System.Threading.Tasks;
using ArchiRedux.Application.Service;
using ArchiRedux.Domain.Model;
using MediatR;

namespace ArchiRedux.Application.Handlers.Commands.AddProduct
{
    public class AddProductHandler: IRequestHandler<AddProductCommand, Product>
    {
        private readonly IProductService _productService;

        public AddProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.AddProduct(request.Product);

            return null;
        }
    }
}