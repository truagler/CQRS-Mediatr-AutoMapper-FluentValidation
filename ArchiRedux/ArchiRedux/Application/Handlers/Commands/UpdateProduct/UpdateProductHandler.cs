using System.Threading;
using System.Threading.Tasks;
using ArchiRedux.Application.Service;
using ArchiRedux.Domain.Model;
using MediatR;

namespace ArchiRedux.Application.Handlers.Commands.UpdateProduct
{
    public class UpdateProductHandler: IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IProductService _productService;

        public UpdateProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.UpdateProduct(request.Product);
            
            return null;
        }
    }
}