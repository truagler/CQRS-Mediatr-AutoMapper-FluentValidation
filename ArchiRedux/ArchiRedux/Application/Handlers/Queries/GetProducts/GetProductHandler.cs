using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ArchiRedux.Application.Service;
using ArchiRedux.Domain.Model;
using MediatR;

namespace ArchiRedux.Application.Handlers.Queries.GetProducts
{
    public class GetProductHandler: IRequestHandler<GetProductQuerie, Task<List<Product>>>
    {
        private readonly IProductService _productService;

        public GetProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public Task<Task<List<Product>>> Handle(GetProductQuerie request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_productService.GetProducts());
        }
    }
}