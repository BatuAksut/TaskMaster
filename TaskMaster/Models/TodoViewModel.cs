using EntityLayer;

namespace TaskMaster.Models
{
    public class TodoViewModel
    {
        public List<TodoItem> TodoItems { get; set; }
        public int? SelectedCategoryId { get; set; }
        public List<Category> Categories { get; set; }
    }


}
