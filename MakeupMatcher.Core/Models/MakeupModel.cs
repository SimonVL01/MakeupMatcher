using System;

namespace MakeupMatcher.Core.Models
{
    public class MakeupModel
    {
        public int _colorId { get; set; }
        public string _colorName { get; set; }
        public ProductModel[] _productModel { get; set; }
    }
}