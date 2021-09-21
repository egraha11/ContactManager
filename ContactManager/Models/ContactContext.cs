using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Models
{
    public class ContactContext : DbContext
    {

        public ContactContext(DbContextOptions<ContactContext> options):base(options)
        {}

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category {
                    CategoryName = "friend",
                    CategoryId = 1
                    },
                new Category
                {
                    CategoryName = "enemy",
                    CategoryId = 2
                }
                );

            
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    FirstName = "Ross",
                    LastName = "Geller",
                    PhoneNumber = "914-000-0000",
                    Email = "Ross.Geller@aol.com",
                    Organization = "Some Museum",
                    CategoryId = 1
                },
                new Contact
                {
                    ContactId = 2,
                    FirstName = "Rachel",
                    LastName = "Green",
                    PhoneNumber = "914-000-0000",
                    Email = "Rachel.Green@aol.com",
                    Organization = "Merchandiser?",
                    CategoryId = 1
                },
               new Contact
               {
                   ContactId = 3,
                   FirstName = "Joseph",
                   LastName = "Tribbiani",
                   PhoneNumber = "914-000-0000",
                   Email = "Joseph.Tribianni@aol.com",
                   Organization = "Actor",
                   CategoryId = 1
               }
                );
        }
    }
}
