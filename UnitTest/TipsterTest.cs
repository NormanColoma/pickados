using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CEN.Pickados;
using Moq;
using PickadosGenNHibernate.CAD.Pickados;
using PickadosGenNHibernate.Exceptions;

namespace UnitTest
{
    [TestClass]
    public class TipsterTest
    {
        [TestMethod]
        public void CorrectLoginTest()
        {
            var userCADMock = new Mock<ITipsterCAD>();

            TipsterEN nuevo = new TipsterEN();
            nuevo.Alias = "Macareno";
            nuevo.Password = "Hola12345";

            userCADMock.Setup(mock => mock.GetByID(It.IsAny<int>())).Returns(nuevo);

            TipsterCEN tipster = new TipsterCEN(userCADMock.Object);

            TipsterEN actual = tipster.GetByID(1);

            Assert.AreEqual(actual.Alias, "Macareno");
            Assert.AreEqual(actual.Password, "Hola12345");

            userCADMock.Verify(mock => mock.GetByID(It.IsAny<int>()), Times.Once);

        }

        [TestMethod]
        public void IncorrectLoginTest()
        {
            var userCADMock = new Mock<ITipsterCAD>();

            TipsterEN nuevo = new TipsterEN();
            nuevo.Alias = "Macareno";
            nuevo.Password = "Hola12345";

            userCADMock.Setup(mock => mock.GetByID(It.IsAny<int>())).Returns(nuevo);

            TipsterCEN tipster = new TipsterCEN(userCADMock.Object);

            TipsterEN actual = tipster.GetByID(1);

            Assert.AreEqual(actual.Alias, "Macareno");
            Assert.AreNotEqual(actual.Password, "Macareno");

            userCADMock.Verify(mock => mock.GetByID(It.IsAny<int>()), Times.Once);

        }

        [TestMethod]
        public void ChangePasswordTest()
        {
            var userCADMock = new Mock<ITipsterCAD>();

            TipsterEN nuevo = new TipsterEN();
            nuevo.Alias = "Macareno";
            nuevo.Password = "Adios12345";

            userCADMock.Setup(mock => mock.GetByID(It.IsAny<int>())).Returns(nuevo);

            TipsterCEN tipster = new TipsterCEN(userCADMock.Object);
            tipster.ModifyTipster(1, new TimeSpan(), new TimeSpan(), "Macareno", "hola@gmail.com", "Adios12345", false, 0);
            TipsterEN actual = tipster.GetByID(1);

            Assert.AreEqual(actual.Alias, "Macareno");
            Assert.AreEqual(actual.Password, "Adios12345");

            userCADMock.Verify(mock => mock.GetByID(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void ChangePasswordFailTest()
        {
            var userCADMock = new Mock<ITipsterCAD>();

            TipsterEN nuevo = new TipsterEN();
            nuevo.Alias = "Macareno";
            nuevo.Password = "Adios12345";

            userCADMock.Setup(mock => mock.ModifyTipster(It.IsAny<TipsterEN>())).Throws(new DataLayerException("Error in TipsterCAD"));

            TipsterCEN tipster = new TipsterCEN(userCADMock.Object);
            try
            {
                tipster.ModifyTipster(1, new TimeSpan(), new TimeSpan(), "Macareno", "hola@gmail.com", "Adios12345", false, 0);
                Assert.Fail("Should throw Datalayer Exception");
            } catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DataLayerException));
                Assert.AreEqual("Error in TipsterCAD", e.Message);
            }

            userCADMock.Verify(mock => mock.ModifyTipster(It.IsAny<TipsterEN>()), Times.Once);

        }

        [TestMethod]
        public void ChangeTipsterPremiumTest()
        {
            var userCADMock = new Mock<ITipsterCAD>();

            TipsterEN nuevo = new TipsterEN();
            nuevo.CreatedAt = new TimeSpan();
            nuevo.ModifiedAt = new TimeSpan();
            nuevo.Alias = "Macareno";
            nuevo.Email = "hola@gmail.com";
            nuevo.Password = "Hola12345";
            nuevo.Premium = true;
            nuevo.Subscription_fee = 1.5;

            userCADMock.Setup(mock => mock.GetByID(It.IsAny<int>())).Returns(nuevo);

            TipsterCEN tipster = new TipsterCEN(userCADMock.Object);
            tipster.BecomePremium(1, 1.5);
            TipsterEN actual = tipster.GetByID(1);

            Assert.IsTrue(actual.Premium);
            Assert.AreEqual(actual.Subscription_fee, actual.Subscription_fee);

            userCADMock.Verify(mock => mock.GetByID(It.IsAny<int>()), Times.AtMost(2));

        }

        [TestMethod]
        public void ChangeTipsterPremiumFailTest()
        {
            var userCADMock = new Mock<ITipsterCAD>();

            TipsterEN nuevo = new TipsterEN();
            nuevo.CreatedAt = new TimeSpan();
            nuevo.ModifiedAt = new TimeSpan();
            nuevo.Alias = "Macareno";
            nuevo.Email = "hola@gmail.com";
            nuevo.Password = "Hola12345";
            nuevo.Premium = true;
            nuevo.Subscription_fee = 1.5;

            userCADMock.Setup(mock => mock.GetByID(It.IsAny<int>())).Returns(nuevo);
            userCADMock.Setup(mock => mock.ModifyTipster(It.IsAny<TipsterEN>())).Throws(new DataLayerException("Error in TipsterCAD"));

            TipsterCEN tipster = new TipsterCEN(userCADMock.Object);
            try
            {
                tipster.BecomePremium(1, 1.5);
                Assert.Fail("Should throw Datalayer Exception");
            } catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DataLayerException));
                Assert.AreEqual("Error in TipsterCAD", e.Message);
            }

            userCADMock.Verify(mock => mock.GetByID(It.IsAny<int>()), Times.Once);
            userCADMock.Verify(mock => mock.ModifyTipster(It.IsAny<TipsterEN>()), Times.Once);

        }

    }
}
