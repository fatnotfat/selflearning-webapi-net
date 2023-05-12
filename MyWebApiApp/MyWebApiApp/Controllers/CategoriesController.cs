using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System.Linq;
using System.Net;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private MyDBContext _context;

        public CategoriesController(MyDBContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            try
            {
                var listCategories = _context.Categories.ToList();
                return Ok(listCategories);

            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{cateID}")]

        public IActionResult GetByID(int cateID)
        {
            var cate = _context.Categories.SingleOrDefault(c => c.CategoryID == cateID);
            if (cate != null) { return Ok(cate); }
            else return NotFound();

        }

        [HttpPost]
        [Authorize]
        public IActionResult AddNewCategory (CategoryModel categoryModel)
        {
            try
            {
                var category = new Category
                {
                    Name = categoryModel.Name
                };
                _context.Add(category);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, category);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{cateID}")]

        public IActionResult UpdateCategoryByID(int cateID, CategoryModel categoryModel)
        {
            var cate = _context.Categories.SingleOrDefault(c => c.CategoryID == cateID);
            if (cate != null) 
            {
                cate.Name = categoryModel.Name;
                _context.SaveChanges();
                return NoContent(); 
            }
            else return NotFound();

        }

        [HttpDelete("{cateID}")]

        public IActionResult DeleteCategoryByID(int cateID)
        {
            var cate = _context.Categories.SingleOrDefault(c => c.CategoryID == cateID);
            if (cate != null) 
            {
                _context.Remove(cate);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            else return NotFound();

        }
    }
}
