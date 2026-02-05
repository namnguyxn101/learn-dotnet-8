using Microsoft.AspNetCore.Mvc;

namespace XTLAB
{
    // [ViewComponent]
    public class ProductBox : ViewComponent
    {
        /**
         * string | IViewComponentResult Invoke(object m)
         * InvokeAsync()
        */

        /**
         * - Có Attribute [ViewComponent]
         * - Tên class có hậu tố "ViewComponent"
         * - Kế thừa từ class ViewComponent (dùng cách này)
        */

        readonly ProductListService ProductListService;

        public ProductBox(ProductListService _ProductListService)
        {
            ProductListService = _ProductListService;
        }

        public IViewComponentResult Invoke(bool saptangdan = true)
        {
            // return View(); // Default.cshtml
            // --------------------------------
            // return View("Default1");
            // --------------------------------
            // return View<string>("Xin chao cac ban");
            // --------------------------------

            List<Product>? _products = null;
            if (saptangdan)
            {
                _products = ProductListService.Products.OrderBy(p => p.Price).ToList();
            }
            else
            {
                _products = ProductListService.Products.OrderByDescending(p => p.Price).ToList();
            }

            return View<List<Product>>(_products);
        }
    }
}