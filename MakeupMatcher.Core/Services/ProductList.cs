using System;
using MakeupMatcher.Core.Models;

namespace MakeupMatcher.Core.Services
{
    public static class ProductList
    {
        static ProductModel[] _productList;

        static ProductList()
        {
            _productList = new ProductModel[] {
                new ProductModel(),
                new ProductModel(),
                new ProductModel(),
                new ProductModel(),
                new ProductModel(),
                new ProductModel(),
                new ProductModel(),
                new ProductModel(),
                new ProductModel(),
                new ProductModel(),
            };

            _productList[0].ProductId = 1; _productList[0].ProductName = "Peach pinkness"; _productList[0].ProductBrand = "Loreal"; _productList[0].ProductPrice = 20.45; _productList[0].Favorite = false; _productList[0].ProductColor = Enum.Colors.Pink;
            _productList[1].ProductId = 2; _productList[1].ProductName = "Font de passion"; _productList[1].ProductBrand = "Vichy"; _productList[1].ProductPrice = 18.85; _productList[1].Favorite = false; _productList[1].ProductColor = Enum.Colors.Magenta;
            _productList[2].ProductId = 3; _productList[2].ProductName = "Fondation de couleur"; _productList[2].ProductBrand = "Dove"; _productList[2].ProductPrice = 14.95; _productList[2].Favorite = false; _productList[2].ProductColor = Enum.Colors.DarkBrown;
            _productList[3].ProductId = 4; _productList[3].ProductName = "Colors of Asia"; _productList[3].ProductBrand = "Loreal"; _productList[3].ProductPrice = 30.88; _productList[3].Favorite = false; _productList[3].ProductColor = Enum.Colors.Ochre;
            _productList[4].ProductId = 5; _productList[4].ProductName = "Fiery fantasy"; _productList[4].ProductBrand = "Be Creative Make Up"; _productList[4].ProductPrice = 23.19; _productList[4].Favorite = false; _productList[4].ProductColor = Enum.Colors.Red;
            _productList[5].ProductId = 6; _productList[5].ProductName = "Déesse de Neige"; _productList[5].ProductBrand = "Loreal"; _productList[5].ProductPrice = 24.55; _productList[5].Favorite = false; _productList[5].ProductColor = Enum.Colors.LittleBlue;
            _productList[6].ProductId = 7; _productList[6].ProductName = "A shade of gloss"; _productList[6].ProductBrand = "Be Creative Make Up"; _productList[6].ProductPrice = 21.64; _productList[6].Favorite = false; _productList[6].ProductColor = Enum.Colors.Pink;
            _productList[7].ProductId = 8; _productList[7].ProductName = "Colors of Atlantis"; _productList[7].ProductBrand = "Loreal"; _productList[7].ProductPrice = 28.55; _productList[7].Favorite = false; _productList[7].ProductColor = Enum.Colors.LittleBlue;
            _productList[8].ProductId = 9; _productList[8].ProductName = "Skin darkener"; _productList[8].ProductBrand = "Be Creative Make Up"; _productList[8].ProductPrice = 26.53; _productList[8].Favorite = false; _productList[8].ProductColor = Enum.Colors.DarkBrown;
            _productList[9].ProductId = 10; _productList[9].ProductName = "Reëlle Magique"; _productList[9].ProductBrand = "Vichy"; _productList[9].ProductPrice = 29.99; _productList[9].Favorite = false; _productList[9].ProductColor = Enum.Colors.TannedBrown;
        }

        public static ProductModel[] GetProductList
        {
            get { return _productList; }
            set {
                _productList = value;
            }
        }
    }
}