using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController(ToDoContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetItems()
        {
            return await context.ToDoItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetItem(int id)
        {
            var item = await context.ToDoItems.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItem>> Create(ToDoItem item)
        {
            context.ToDoItems.Add(item);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ToDoItem item)
        {
            if (id != item.Id) return BadRequest();
            context.Entry(item).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await context.ToDoItems.FindAsync(id);
            if (item == null) return NotFound();
            context.ToDoItems.Remove(item);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
