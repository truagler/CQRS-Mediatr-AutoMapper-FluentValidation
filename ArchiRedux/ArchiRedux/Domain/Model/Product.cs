using System;

namespace ArchiRedux.Domain.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Int32 Price { get; set; }
        public Boolean IsRemoved { get; set; }

        public Product() { }

        public Product(Guid id, string name, int price, bool isRemoved)
        {
            Id = id;
            Name = name;
            Price = price;
            IsRemoved = isRemoved;
        }
    }
}