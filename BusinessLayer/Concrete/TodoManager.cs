using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TodoManager : ITodoService
    {
        ITodoDal todoDal;

        public TodoManager(ITodoDal todoDal)
        {
            this.todoDal = todoDal;
        }

        public void Add(TodoItem todoItem)
        {
            todoDal.Add(todoItem);
        }

        public void Delete(TodoItem todoItem)
        {
            todoDal.Delete(todoItem);
        }

        public List<TodoItem> GetAll()
        {
            return todoDal.GetAll();
        }

        public TodoItem GetById(int id)
        {
            return todoDal.Get(x=>x.TodoId==id);
        }

        public void Update(TodoItem todoItem)
        {
            todoDal.Update(todoItem);
        }
    }
}
