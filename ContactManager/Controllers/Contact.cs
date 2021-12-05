using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Controllers
{
    public class Contact : Controller
    {

        //public ContactContext context;

        IRepository<ContactManager.Models.Contact> data { get; set; }

        /**
        public Contact(ContactContext ctx)
        {
            context = ctx;
        }
        **/

        public Contact(IRepository<ContactManager.Models.Contact> rep)
        {
            data = rep;
        }

        public IActionResult Details(int id)
        {
            var contact = data.Get(id);
            ViewBag.CategoryName = data.Get(contact.CategoryId);

            return View(contact);
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = data.List("Category").OrderBy(c => c.CategoryId);
            return View("Edit", new Models.Contact());
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            var contact = data.Get(id);
            ViewBag.Action = "Edit";
            ViewBag.Categories = data.List("Category").OrderBy(c => c.CategoryId);

            return View(contact);
        }


        [HttpPost]
        public IActionResult Edit(Models.Contact contact)
        {
            if (ModelState.IsValid)
            {
                if(contact.ContactId == 0)
                {
                    data.Insert(contact);
                }
                else
                {
                    data.Update(contact);
                }
                data.Save();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = ( contact.ContactId == 0) ? "Add" : "Edit";
                ViewBag.Categories = data.List("Category").OrderBy(c => c.CategoryId);
                return View(contact);
            }
        }




        [HttpGet]
        public IActionResult Delete(int id)
        {

            var contact = data.Get(id);

            return View(contact);
        }


        [HttpPost]
        public IActionResult Delete(Models.Contact contact)
        {

            data.Delete(contact);
            data.Save();

            return RedirectToAction("Index", "Home");
        }
    }
}
