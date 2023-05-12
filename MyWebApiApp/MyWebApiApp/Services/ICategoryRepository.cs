using MyWebApiApp.Models;
using System.Collections.Generic;

namespace MyWebApiApp.Services
{
    public interface ICategoryRepository
    {
        List<CategoryVM> GetAll();
        CategoryVM GetByID(int cateID);
        CategoryVM AddNewCategory(CategoryModel category);
        void Update(CategoryVM category);
        void Remove(int cateID);
    }
}
