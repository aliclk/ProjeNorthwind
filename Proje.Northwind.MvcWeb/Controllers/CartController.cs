using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proje.Northwind.Business.Abstract;
using Proje.Northwind.MvcWeb.Services;

namespace Proje.Northwind.MvcWeb.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private IProductService _productService;

        public CartController(ICartSessionService cartSessionService, ICartService cartService, IProductService productService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService = productService;
        }

        public ActionResult AddToCart(int productId)
        {
            var productToAdded = _productService.GetById(productId);

            var cart = _cartSessionService.GetCart();

            _cartService.AddToCart(cart,productToAdded);

            _cartSessionService.SetCart(cart);

            TempData.Add("message", String.Format("Your product,{0},was successfully added to the cart",productToAdded.ProductName));
            return RedirectToAction("Index", "Product");
        }
    }
}