using System;

namespace ArchiRedux.Framework.Dto
{
    public class ProductDto
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public Int32 Price { get; set; }
        
        public Boolean IsRemoved { get; set; }

    }
}