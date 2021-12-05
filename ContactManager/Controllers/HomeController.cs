using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {

        ContactContext context { get; set; }

        IRepository<ContactManager.Models.Contact> data { get; set; }


        public HomeController(IRepository<ContactManager.Models.Contact> rep)
        {
            data = rep;
        }


        /**
        public HomeController(ContactContext ctx)
        {
            context = ctx;
        }
        **/



        public IActionResult Index()
        {
            //var contacts = context.Contacts.Include(c => c.Category).OrderBy(c => c.FirstName).ToList();

            var contacts = data.List("Category");
            return View(contacts);
        }




        /**
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        **/
    }
}
