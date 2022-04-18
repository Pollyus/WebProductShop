using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductShop.DataBase;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ProductShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        [HttpGet]

        public IEnumerable<Basket> GetAll()
        {
            using (var context = new ProductShopContext())
            {
                return context.ShoppingCarts.Join(context.Products, sb => sb.ProductId, prod => prod.Id,
                    (sb, prod) => new Basket
                    {
                        ByuerId = sb.BuyerId,
                        Id = sb.Id,
                        ProductId = sb.ProductId,
                        Number = sb.Amount,
                        ProductName = prod.Name
                    }).ToList();
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetType([FromRoute] int id)
        {
            using (var context = new ProductShopContext())
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var type = await context.ShoppingCarts.SingleOrDefaultAsync(m =>
                m.Id == id);
                if (type == null)
                {
                    return NotFound();
                }
                return Ok(type);
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Create(/*[FromBody] Product type*/ [FromRoute] int id)
        {
            using (var context = new ProductShopContext())
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                ShoppingCart basket = new ShoppingCart();
                basket.ProductId = id;
                basket.BuyerId = 2;
                context.ShoppingCarts.Add(basket);
                await context.SaveChangesAsync();
                return CreatedAtAction("GetType", new { id = basket.Id }, basket);
            }
        }

        [HttpPut("{id}/{value}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromRoute] int value)
        {
            using (var context = new ProductShopContext())
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var item = context.ShoppingCarts.Find(id);
                if (item == null)
                {
                    return NotFound();
                }
                item.Amount = item.Amount + value;
                context.ShoppingCarts.Update(item);
                await context.SaveChangesAsync();
                return NoContent();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            using (var context = new ProductShopContext())
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var item = context.ShoppingCarts.Find(id);
                if (item == null)
                {
                    return NotFound();
                }
                context.ShoppingCarts.Remove(item);
                await context.SaveChangesAsync();
                return NoContent();
            }
        }
    }
}
