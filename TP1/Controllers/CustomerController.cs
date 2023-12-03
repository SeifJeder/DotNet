using DotnetTP1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetTP1.Controllers
{
    public class CustomerController : Controller
    {


        public List<Customer> customers = new List<Customer>()
        {
            new Customer() { Id = 1,Name="Mohamed"},
            new Customer() { Id = 2,Name="Rebai"},

        };


        public ActionResult Index()
        {
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var c = customers.Find((customer) => (customer.Id == id));
            if(c == null)
            {
                return Content("Customer Not Found");
            }
            return View(c);
        }

    }
}
