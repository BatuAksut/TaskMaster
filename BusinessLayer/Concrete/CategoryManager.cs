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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }
        public void Add(Category category)
        {
            categoryDal.Add(category);
        }

        public void Delete(Category category)
        {
            categoryDal.Delete(category);
        }

        public List<Category> GetAll()
        {
            return categoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            return categoryDal.Get(x=>x.CategoryId == id);
        }

        public void Update(Category category)
        {
            categoryDal.Update(category);
        }
    }
}
