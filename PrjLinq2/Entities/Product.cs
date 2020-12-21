using System;
namespace PrjLinq2.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }

        public override string ToString()
        {
            return Id
                + ","
                + Name
                + ","
                + Price
                + ","
                + Category.Name
                + ","
                + Category.Tier;

        }

    }
}
