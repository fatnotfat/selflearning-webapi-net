using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> products = new List<Product>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(string id)
        {
            try
            {
                //LINQ Object Query
                var product = products.SingleOrDefault(p => p.ProductID == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public IActionResult Create(ProductVM productVM) 
        {
            var product = new Product {
                ProductID = Guid.NewGuid(),
                ProductName = productVM.ProductName,
                ProductPrice = productVM.ProductPrice,
            };  
            products.Add(product);
            return Ok(new
            {
                Success = true,
                Data = product
            });
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Product productUpdate)
        {
            try
            {
                //LINQ Object Query
                var product = products.SingleOrDefault(p => p.ProductID == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                 
                if(id != product.ProductID.ToString())
                {
                    return BadRequest();
                }

                //Update
                product.ProductName = productUpdate.ProductName;
                product.ProductPrice = productUpdate.ProductPrice;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                //LINQ Object Query
                var product = products.SingleOrDefault(p => p.ProductID == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }

                if (id != product.ProductID.ToString())
                {
                    return BadRequest();
                }

                //Delete
                products.Remove(product);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
