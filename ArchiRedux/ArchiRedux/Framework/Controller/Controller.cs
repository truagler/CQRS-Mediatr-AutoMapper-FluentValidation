using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArchiRedux.Application.Handlers.Commands.AddProduct;
using ArchiRedux.Application.Handlers.Commands.UpdateProduct;
using ArchiRedux.Application.Handlers.Queries.GetProductById;
using ArchiRedux.Application.Handlers.Queries.GetProducts;
using ArchiRedux.Domain.Model;
using ArchiRedux.Framework.Dto;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArchiRedux.Framework.Controller
{
    public class Controller: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private IValidator<ProductDto> _validator;

        public Controller(IMapper mapper, IMediator mediator, IValidator<ProductDto> validator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _validator = validator;
        }

        [HttpPost]
        [Route("/addproduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            ValidationResult result = await _validator.ValidateAsync(productDto);

            if (result.IsValid)
            {
                await _mediator.Send(new AddProductCommand(_mapper.Map<Product>(productDto)));
            }
            
            return Ok(result.Errors.Select(x => x.ErrorMessage) ?? null);
        }

        [HttpPost]
        [Route("/updateproduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto productDto)
        {
            ValidationResult result = await _validator.ValidateAsync(productDto);

            if (result.IsValid)
            {
                await _mediator.Send(new UpdateProductCommand(_mapper.Map<Product>(productDto)));
            }

            return Ok(result.Errors ?? null);
        }

        [HttpGet]
        [Route("/getproduct/{id?}")]
        public Task<Product> GetProduct(Guid id)
        {
            return Task.FromResult(_mediator.Send(new GetProductByIdQuerie(id)).Result.Result);
        }

        [HttpGet]
        [Route("/getproducts")]
        public Task<List<Product>> GetProducts()
        {
            return Task.FromResult(_mediator.Send(new GetProductQuerie()).Result.Result);
        }
    }
}