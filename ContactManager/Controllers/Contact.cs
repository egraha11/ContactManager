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

        public ContactContext context;


        public Contact(ContactContext ctx)
        {
            context = ctx;
        }

        public IActionResult Details(int id)
        {
            var contact = context.Contacts.Find(id);
            ViewBag.CategoryName = context.Categories.Find(contact.CategoryId);
            return View(contact);
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = context.Categories.ToList().OrderBy(c => c.CategoryId);
            return View("Edit", new Models.Contact());
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            var contact = context.Contacts.Find(id);
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.ToList().OrderBy(c => c.CategoryId);

            return View(contact);
        }


        [HttpPost]
        public IActionResult Edit(Models.Contact contact)
        {
            if (ModelState.IsValid)
            {
                if(contact.ContactId == 0)
                {
                    context.Contacts.Add(contact);
                }
                else
                {
                    context.Update(contact);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = ( contact.ContactId == 0) ? "Add" : "Edit";
                return View(contact);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            var contact = context.Contacts.Find(id);

            return View(contact);
        }


        [HttpPost]
        public IActionResult Delete(Models.Contact contact)
        {

            context.Contacts.Remove(contact);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
