using DuplexCenima.Data.Cart;
using DuplexCenima.Data.Services;
using DuplexCenima.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DuplexCenima.Controllers
{
    public class OrdersController : Controller
    {
        private readonly iMoviesService _moviesService;
        private readonly ShoppingCart _shoppingCart;
        public OrdersController(iMoviesService moviesService, ShoppingCart shoppingCart)
        {
            _moviesService = moviesService;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response); 
        }
    }
}
