using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.Concrete;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TaskMaster.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;
        private readonly ICategoryService _categoryService;
        private TodoContext todoContext = new TodoContext();

        public TodoController(ITodoService todoService,ICategoryService categoryService)
        {
            _todoService = todoService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var todoData = todoContext.TodoItems.Include(t => t.Category).ToList();
            return View(todoData);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var categories = _categoryService.GetAll() ?? new List<Category>();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
		public IActionResult Add(TodoItem todoItem)
		{
			{
                
                _todoService.Add(todoItem);
				return RedirectToAction("Index");

			}
		}
	}
}
