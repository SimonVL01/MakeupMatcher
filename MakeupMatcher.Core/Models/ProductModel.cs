using System;

namespace MakeupMatcher.Core.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        //public enum ProductColor { get; set; }
        public string ProductBrand { get; set; }
        public double ProductPrice { get; set; }
        public bool Favorite { get; set; } = false;
    }
}