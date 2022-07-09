using System.Collections.Generic;
using System.Threading.Tasks;
using ArchiRedux.Domain.Model;
using MediatR;

namespace ArchiRedux.Application.Handlers.Queries.GetProducts
{
    public class GetProductQuerie: IRequest<Task<List<Product>>> { }
}