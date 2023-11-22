using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal CategoryDal)
        {
            _categoryDal = CategoryDal;
        }

        public void Delete(Category Category)
        {
            _categoryDal.Delete(Category);
        }

        public Category GetById(int Id)
        {
            return _categoryDal.GetByID(Id);
        }


        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

     
        public void Insert(Category Category)
        {
            _categoryDal.Insert(Category);
        }

        public void Update(Category Category)
        {
            _categoryDal.Update(Category);
        }
    }
}
