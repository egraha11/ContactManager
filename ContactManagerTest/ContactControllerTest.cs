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
    public class ContactControllerTest
    {


        public static Mock<IRepository<ContactManager.Models.Contact>> buildRep()
        {

            return new Mock<IRepository<ContactManager.Models.Contact>>();
        }

        [Theory]
        [InlineData(0)]
        public void DetailsActionMethod_ReturnsViewResult(int id)
        {
            //arrange
            var rep = buildRep();
            rep.Setup(c => c.Get(It.IsAny<int>())).Returns(new ContactManager.Models.Contact());

            var controller = new ContactManager.Controllers.Contact(rep.Object);

            //act
            var result = controller.Details(id);

            //assert
            Assert.IsType<ViewResult>(result);
        }






        [Fact]
        public void PostEditActionMethod_ReturnsViewResultIfModelStateIsValid()
        {
            //arrange
            var rep = buildRep();
            rep.Setup(c => c.Insert(It.IsAny<ContactManager.Models.Contact>()));

            var controller = new ContactManager.Controllers.Contact(rep.Object);

            //act
            var result = controller.Edit(new ContactManager.Models.Contact());

            //assert
            Assert.IsType<RedirectToActionResult>(result);
        }


        [Fact]
        public void PostEditActionMethod_ReturnsViewResultIfModelStateIsNotValid()
        {
            //arrange
            var rep = buildRep();

            var controller = new ContactManager.Controllers.Contact(rep.Object);
            controller.ModelState.AddModelError("", "Test Error Message");

            //act
            var result = controller.Edit(new ContactManager.Models.Contact());
            
            //assert
            Assert.IsType<ViewResult>(result);
        }





        [Theory]
        [InlineData(1)]
        public void GetDeleteActionMethod_ReturnsViewResult(int id)
        {
            //arrange
            var rep = buildRep();
            rep.Setup(c => c.Get(It.Is<int>(i => 1 >= 0))).Returns(new ContactManager.Models.Contact());
            var controller = new ContactManager.Controllers.Contact(rep.Object);

            //act
            var result = controller.Delete(id);


            //assert
            Assert.IsType<ViewResult>(result);

        }




        [Fact]
        public void PostDeleteActionMethod_ReturnsRedirect()
        {
            //arrange
            var rep = buildRep();
            rep.Setup(c => c.Delete(It.IsAny<ContactManager.Models.Contact>()));
            rep.Setup(c => c.Save());
            var controller = new ContactManager.Controllers.Contact(rep.Object);

            //act
            var result = controller.Delete(new ContactManager.Models.Contact());

            //assert
            Assert.IsType<RedirectToActionResult>(result);

        }
    }
}
