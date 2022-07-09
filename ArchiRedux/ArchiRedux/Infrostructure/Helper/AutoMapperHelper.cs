using ArchiRedux.Domain.Model;
using ArchiRedux.Framework.Dto;
using AutoMapper;

namespace ArchiRedux.Infrostructure.Helper
{
    public class AutoMapperHelper: Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<ProductDto, Product>();
        }
    }
}