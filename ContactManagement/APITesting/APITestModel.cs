using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace APITesting
{
    [TestClass]
    public class APITestModel
    {
        private readonly BusinessLayer.Repositories.IContactRepository businessLayer;
        private readonly API.Controllers.ContactController contactController;

        public APITestModel()
        {
            businessLayer = new BusinessLayer.Repositories.ContactRepository();
            contactController = new API.Controllers.ContactController(businessLayer);
        }

        [TestMethod]
        public void GetContactTest()
        {
            var x = businessLayer.GetAll().Count;
            var y = contactController.Get().Count;

            Assert.AreEqual(x, y);
        }


        [TestMethod]
        public void DeleteContactTest()
        {
            var x = businessLayer.GetAll().Count;
            var y = contactController.Delete(1);

            if (y.Contains("successful"))
            {
                Assert.AreEqual(x, x - 1);
            }
            else
            {
                Assert.AreNotEqual(x, x - 1);
            }

        }


        [TestMethod]
        public void UpdateContactTest()
        {
            var x = businessLayer.GetAll().Count;

            contactController.Update(new BusinessLayer.Models.Contact { ID=1, EMail="abc@gmail.com" });
            var y = businessLayer.GetAll().Count;


            Assert.AreEqual(x, y);

        }


        [TestMethod]
        public void AddContactTest()
        {
            var x = businessLayer.GetAll().Count;

            var y = contactController.Add(new BusinessLayer.Models.Contact { EMail = "xyz@gmail.com" });
            var z = businessLayer.GetAll().Count;

            if (y.Contains("successful"))
            {
                Assert.AreEqual(x+1, z);
            }
            else
            {
                Assert.AreNotEqual(x, z);
            }

        }
    }
}
