using NUnit.Framework;
using ToDoApi.Controllers;
using ToDoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDoApi.Tests
{
    public class TodoControllerTests
    {
        private ToDoContext _context;
        private ToDoController _controller;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ToDoContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;

            _context = new ToDoContext(options);
            _controller = new ToDoController(_context);
        }

        [Test]
        public async Task GetTodos_ReturnsAllItems()
        {
            _context.ToDoItems.Add(new ToDoItem { Title = "Test 1", Description = "Test Desc" });
            _context.ToDoItems.Add(new ToDoItem { Title = "Test 2", Description = "Test Desc 2" });
            await _context.SaveChangesAsync();

            var result = await _controller.GetItems();
            
            var items = result?.Value;

            var toDoItems = items?.ToList();
            
            Assert.That(toDoItems, Is.Not.Null);
            Assert.That(toDoItems, Has.Exactly(2).Items);
        }
    }
}
