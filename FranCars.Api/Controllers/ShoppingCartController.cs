using FranCars.Api.Data.Repositories;
using FranCars.Shared.Dtos;
using FranCars.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace FranCars.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IShoppingItemRepository _shoppingItemRepository;

        public ShoppingCartController (IShoppingCartRepository shoppingCartRepository, IShoppingItemRepository shoppingItemRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _shoppingItemRepository = shoppingItemRepository;
        }

        [HttpGet("userId={userId}")]
        public IActionResult GetShoppingCartByUserId(int userId)
        {
            var shoppingCart = _shoppingCartRepository.GetByUserId(userId);
            return Ok(shoppingCart);
        }

        [HttpPost("addItem")]
        public IActionResult AddItemToShoppingCart(ProductItemDto dto)
        {

            var shoppingCart = _shoppingCartRepository.GetByUserId(dto.UserId);
            var shoppingItem = new ShoppingItem
            {
                ShoppingCartId = shoppingCart.Id,
                ProductName = $"{dto.Make} {dto.Model}",
                Price = dto.Price
            };
            return Created("success", _shoppingItemRepository.Add(shoppingItem));
        }
    }
}
