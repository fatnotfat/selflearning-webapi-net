using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApiApp.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDBContext _context;

        public CategoryRepository(MyDBContext context)
        {
            _context = context;
        }

        public CategoryVM AddNewCategory(CategoryModel category)
        {
            var _category = new Category
            {
                Name = category.Name
            };
            _context.Add(_category);
            _context.SaveChanges();
            return new CategoryVM {
                CategoryID = _category.CategoryID,
                Name = _category.Name
            };
        }

        public List<CategoryVM> GetAll()
        {
            var categories = _context.Categories.Select(c => new CategoryVM
            {
                CategoryID = c.CategoryID,
                Name = c.Name
            });
            return categories.ToList();
        }

        public CategoryVM GetByID(int cateID)
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryID.Equals(cateID));
            if (category != null)
            {
                return new CategoryVM
                {
                    CategoryID = category.CategoryID,
                    Name = category.Name
                };
            }
            else return null;
        }

        public void Remove(int cateID)
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryID.Equals(cateID));
            if(category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public void Update(CategoryVM category)
        {
            var _category = _context.Categories.SingleOrDefault(c => c.CategoryID.Equals(category.CategoryID));
            if (_category != null)
            {
                _category.Name = category.Name;
                _context.Update(_category);
                _context.SaveChanges();
            }
        }
    }
}
