using ArchiRedux.Domain.Model;
using FluentValidation;

namespace ArchiRedux.Framework.Dto
{
    public class ProductDtoValidator: AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Price).NotEmpty();
        }
    }
}