using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers {

    [Route("api/[controller]")]
    public class ProductsController : Controller {
        // Add actions here
        /* [HttpGet]
        public Product[] GetAllProducts() {
            return FakeData.Products.Values.ToArray();
        }*/
        [HttpGet]
        public ActionResult Get() {
            if (FakeData.Products != null) {
                return Ok(FakeData.Products.Values.ToArray());
            } else {
                return NotFound();
            }
        }
        [HttpGet("{id}")]
        public Product Get(int id) {
            if (FakeData.Products.ContainsKey(id))
                return FakeData.Products[id];
            else
                return null;
        }
       /*  [HttpPost]
        public Product Post([FromBody]Product product) {
            product.ID = FakeData.Products.Keys.Max() + 1;
            FakeData.Products.Add(product.ID, product);
            return product; // contains the new ID
        }*/
        [HttpPost]
        public ActionResult Post([FromBody]Product product) {
            product.ID = FakeData.Products.Keys.Max() + 1;
            FakeData.Products.Add(product.ID, product);
            return Created($"api/products/{product.ID}", product); // contains the new ID
        }
        /* [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product product) {
            
            if (FakeData.Products.ContainsKey(id)) {
                var target = FakeData.Products[id];
                target.ID = product.ID;
                target.Name = product.Name;
                target.Price = product.Price;
            }
        }*/
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Product product) {
            if (FakeData.Products.ContainsKey(id)) {
                var target = FakeData.Products[id];
                target.ID = product.ID;
                target.Name = product.Name;
                target.Price = product.Price;
                return Ok();
            } else {
                return NotFound();
            }
        }
       /*  [HttpDelete("{id}")]
        public void Delete(int id) {
            if (FakeData.Products.ContainsKey(id)) {
                FakeData.Products.Remove(id);
            }
        }*/
        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            if (FakeData.Products.ContainsKey(id)) {
                FakeData.Products.Remove(id);
                return Ok();
            } else {
                return NotFound();
            }
        }
        [HttpGet("from/{low}/to/{high}")]
        public Product[] Get(int low, int high) {
            var products = FakeData.Products.Values
            .Where(p => p.Price >= low && p.Price <= high).ToArray();
            return products;
        }

    }
}