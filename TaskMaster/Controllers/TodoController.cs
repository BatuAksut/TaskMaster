using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.Concrete;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskMaster.Models;

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
        public IActionResult Index(int? selectedCategoryId)
        {
            var todoViewModel = new TodoViewModel
            {
                SelectedCategoryId = selectedCategoryId,
                Categories = todoContext.Categories.ToList(), // Tüm kategorileri alın
                TodoItems = todoContext.TodoItems
                    .Include(t => t.Category)
                    .Where(t => !t.IsCompleted &&
                                (selectedCategoryId == null || t.CategoryId == selectedCategoryId))
                    .ToList()
            };

            return View(todoViewModel);
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

        [HttpPost]
        public IActionResult Complete(int id)
        {
            var todoItem = todoContext.TodoItems.FirstOrDefault(t => t.TodoId == id);

            if (todoItem != null)
            {
                todoItem.IsCompleted = true;
                todoContext.SaveChanges();
            }

            return RedirectToAction("Index"); // Tamamlanmış görevleri listelemeden geri dön
        }
    }
}
