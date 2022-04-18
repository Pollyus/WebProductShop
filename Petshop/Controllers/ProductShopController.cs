using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductShop.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ProductShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductShopController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            using (var context = new ProductShopContext())
            {
                return context.Products./*Include(p => p.Product).*/ToList();
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
                var type = await context.Products./*Include(p => p.Product).*/SingleOrDefaultAsync(m =>
                m.Id == id);
                if (type == null)
                {
                    return NotFound();
                }
                return Ok(type);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product type)
        {
            using (var context = new ProductShopContext())
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                context.Products.Add(type);
                await context.SaveChangesAsync();
                return CreatedAtAction("GetType", new { id = type.CategoryId }, type);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Product type)
        {
            using (var context = new ProductShopContext())
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var item = context.Products.Find(id);
                if (item == null)
                {
                    return NotFound();
                }
                item.Name = type.Name;
                context.Products.Update(item);
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
                var item = context.Products.Find(id);
                if (item == null)
                {
                    return NotFound();
                }
                context.Products.Remove(item);
                await context.SaveChangesAsync();
                return NoContent();
            }
        }
    }
}
