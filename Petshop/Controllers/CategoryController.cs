﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductShop.DataBase;
using ProductShop.Models;

namespace ProductShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ProductShopContext _context;

        public CategoryController(ProductShopContext context)
        {
            _context = context;
            if (_context.Categories.Count() == 0)
            {
                _context.Categories.Add(new Category { CategoryName = "Бакалея" });
                _context.Categories.Add(new Category { CategoryName = "Овощи и фрукты" });
                _context.Categories.Add(new Category { CategoryName = "Сладкое" });
                _context.SaveChanges();
            }
        }


        [HttpGet]
        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.Include(p => p.Products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _context.Categories.Include(p => p.Products).SingleOrDefaultAsync(m =>
             m.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Categories.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.CategoryName = category.CategoryName;
            _context.Categories.Update(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Categories.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
