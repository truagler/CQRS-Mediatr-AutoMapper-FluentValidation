using System.Threading;
using System.Threading.Tasks;
using ArchiRedux.Application.Service;
using ArchiRedux.Domain.Model;
using MediatR;

namespace ArchiRedux.Application.Handlers.Queries.GetProductById
{
    public class GetProductHandler: IRequestHandler<GetProductByIdQuerie, Task<Product>>
    {
        private readonly IProductService _productService;

        public GetProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public Task<Task<Product>> Handle(GetProductByIdQuerie request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_productService.GetProductById(request.Id));
        }
    }
}