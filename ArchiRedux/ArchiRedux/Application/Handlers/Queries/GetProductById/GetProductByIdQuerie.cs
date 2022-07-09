using System;
using System.Threading.Tasks;
using ArchiRedux.Domain.Model;
using MediatR;

namespace ArchiRedux.Application.Handlers.Queries.GetProductById
{
    public class GetProductByIdQuerie: IRequest<Task<Product>>
    {
        public Guid Id { get; set; }

        public GetProductByIdQuerie(Guid id)
        {
            Id = id;
        }
    }
}