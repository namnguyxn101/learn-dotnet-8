// using MyNameSpace;
// using Abc = MyNameSpace.Abc;
// // Class1 trong namespace MyNameSpace
// Class1.XinChao();
// // Class1 trong namespace Abc của namespace MyNameSpace
// Abc.Class1.XinChao();
//==================================================

using static System.Console;

SanPham.Product product = new SanPham.Product();
product.Name = "iPad";
product.Price = 1000;
product.Description = "Day la iPad";
product.manufactory = new SanPham.Product.Manufactory();
product.manufactory.Name = "Apple";
product.manufactory.Address = "Hoa Ky";
WriteLine(product.GetInfo());