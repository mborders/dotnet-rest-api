using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly TodoContext _context;

        public CategoryController(TodoContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public ActionResult<List<Category>> GetAll()
        {
            return _context.Categories
                .OrderBy(t => t.Id)
                .ToList();
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public ActionResult<Category> GetById(long id)
        {
            var item = _context.Categories.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return CreatedAtRoute("GetCategory", new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Category category)
        {
            var existing = _context.Categories.Find(id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = category.Name;

            _context.Categories.Update(existing);
            _context.SaveChanges();
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }
    }
}