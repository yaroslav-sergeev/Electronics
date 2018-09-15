using System;

namespace Electronics.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Dimentions { get; set; }
        public double Weight { get; set; }
        public string Os { get; set; }
        public double Discount { get; set; }
        public byte[] ImageData { get; set; }
        public string ImagePath { get; set; }
        public int Price { get; set; }
    }
}
