using System;
using System.Collections.Generic;
using System.Text;
using ContactManager.Controllers;
using ContactManager.Models;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagerTest
{
    public class HomeControllerTests
    {


        [Fact]
        public void IndexActionMethod_ReturnsAView()
        {


            //arrange
            var rep = new Mock<IRepository<ContactManager.Models.Contact>>();

            var controller = new HomeController(rep.Object);

            //act
            var result = controller.Index();

            //assert
            Assert.IsType<ViewResult>(result);
        }
    }

}
