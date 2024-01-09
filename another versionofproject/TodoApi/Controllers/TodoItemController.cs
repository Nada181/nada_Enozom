using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/TodoItem")] //name after api/ can be anyname dont get confused
    [ApiController]
    #region convention
    [ApiConventionType(typeof(DefaultApiConventions))]
    #endregion
    //public class TodoItemController : ControllerBase
    public class TodoItemController : Controller
    {
        List<Product> todoItems = new List<Product>(); //create list from TodoItem its name is todoItems
        public TodoItemController() {
            todoItems.Add(new Product
            {
                ProductId = 1,
                ProductName = "HP Laptop 15",
                ProductCategories = "HP",
                
                IsComplete = true,
            });
            todoItems.Add(new Product
            {
                ProductId = 2,
                ProductName = "iphone 15",
                ProductCategories = "Apple",
                IsComplete = true,
            });;
            todoItems.Add(new Product
            {
                ProductId = 3,
                ProductName = "Samsung s32",
                ProductCategories = "Samsung",

                IsComplete = true,
            });
            todoItems.Add(new Product
            {
                ProductId = 4,
                ProductName = "Samsung  LED Screen 32",
                ProductCategories = "Samsung",
                IsComplete = true,
            });
        }
        [HttpGet]
        public List<Product> Get() //to get (all) the avaliable products
        {
            return todoItems;
        }

        [HttpGet("getByname")] //we add the part of {id} to route as we have used HttpGet more than one time
        public ActionResult<Product> GetByname(string productname) {
            var item = todoItems.Find(a => a.ProductName == productname);
            
            if (item == null)
            return NotFound("Product doesn't occur");
            return item;
        }
        [HttpGet("getBycategory")] //we add the part of {id} to route as we have used HttpGet more than one time
        public ActionResult<Product> GetBycategory(string productcategory)
        {
            var item = todoItems.Find(a => a.ProductCategories == productcategory);

            if (item == null)
            return NotFound("Product doesn't occur");
            return item;
        }


        [HttpPost]

        public ActionResult Post([FromBody] Product addedItem) //we add frombody so we can add the item if we remove this part the item won't be added can remove it if API controller occur
        {
            if (ModelState.IsValid) // if API controller occur we can remove this line 
            {
                todoItems.Add(addedItem);
                return CreatedAtAction("GetById", new { id = addedItem.ProductId }, todoItems);
            }
            return BadRequest(); //and this
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Product updateItem)
        {
            //check if not exits
            var eitem = todoItems.Find(a => a.ProductId == id); //todoItems is my list
            if (eitem == null)
                return NotFound();

            foreach (var item in todoItems)
            {
                if (item.ProductId == id)
                {
                    item.ProductName = updateItem.ProductName; //update name of the item of Id=id
                    
                }
            }
             //return Ok(updateItem.Name); will return my update only not with all its information (if I update a name it will return that name only)
            return Ok(todoItems);
            //return NoContent(); //when id occur and we update it 
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTodoItem(int id)
        {
            var todoItem = todoItems.Find(a => a.ProductId == id);
            if (todoItem == null)
            {
                return NotFound();
            }
            todoItems.Remove(todoItem);
            return Ok("deleted sucessfully");
            //return NoContent();
        }
    }   
    
   
    
    
}
