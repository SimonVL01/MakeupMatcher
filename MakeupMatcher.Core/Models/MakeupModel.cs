using System;
using MvvmCross.Core.ViewModels;
using MakeupMatcher.Core.Models;

namespace MakeupMatcher.Core.Models
{
    public class MakeupModel
    {
        public int _colorId { get; set; }
        public string _colorName { get; set; }
        public ProductModel[] _productModel { get; set; }
    }
}