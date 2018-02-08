using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System.Collections.Generic;

namespace Project.Controllers
{
    public class ItemsController : Controller
    {

        [HttpGet("/items")]
        public ActionResult Index()
        {
            List<Item> allItems = Item.GetAll();
            return View(allItems);
        }

        [HttpGet("/items/new")]
        public ActionResult CreateForm()
        {
            return View();
        }


        [HttpPost("/items/delete")]
       public ActionResult DeleteAll()
       {
           Item.ClearAll();
           return View();
       }

       [HttpGet("/categories/{categoryId}/items/new")]
       public ActionResult CreateForm(int categoryId)
       {
          Category category = Category.Find(categoryId);
          return View(category);
       }

       [HttpGet("/categories/{categoryId}/items/{itemId}")]
       public ActionResult Details(int categoryId, int itemId)
       {
          Item item = Item.Find(itemId);
          Dictionary<string, object> model = new Dictionary<string, object>();
          Category category = Category.Find(categoryId);
          model.Add("item", item);
          model.Add("category", category);
          return View(item);
       }
    }
}
