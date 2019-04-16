using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proje.Northwind.Business.Abstract;
using Proje.Northwind.Entities.Concrete;
using Proje.Northwind.MvcWeb.Models;
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
        public ActionResult List()
        {
            var cart = _cartSessionService.GetCart();
            CartListViewModel cartlistviewmodel = new CartListViewModel
            {
                Cart=cart
            };
            return View(cartlistviewmodel);
        }
        public ActionResult Remove(int productId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, productId);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", String.Format("Your product was successfully removed from the cart"));
            return RedirectToAction("List");
        }
        public ActionResult Complete()
        {
            ShippingDetailsViewModel sdvm = new ShippingDetailsViewModel
            {
                ShippingDetails = new ShippingDetails()
            };
            return View(sdvm);
        }
        [HttpPost]
        public ActionResult Complete(ShippingDetails shippingDetails)
        {
            if (!ModelState.IsValid)//Formu doldurmuşmu isim soyisim vb.
            {
                return View();//doldurmadıysa aynı sayfayı göster.
            }
            TempData.Add("message", string.Format("Thank you {0},you order is in process", shippingDetails.FirstName));
            return View();
        }
    }
}