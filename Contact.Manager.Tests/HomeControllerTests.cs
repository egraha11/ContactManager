using System;
using Xunit;
using ContactManager.Controllers;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using ContactManager;
using Moq;

namespace Contact.Manager.Tests
{
    public class HomeControllerTests
    {


        [Fact]
        public void IndexActionMethod_ReturnsAView()
        {


            //arrange
            var rep = new Mock<IRepository<Contact>>();
            rep.Setup(c => c.)

            var controller = new HomeController(rep.Object);

            //act
            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }
    }

}
