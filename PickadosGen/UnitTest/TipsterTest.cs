using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CEN.Pickados;
using Moq;
using PickadosGenNHibernate.CAD.Pickados;
using PickadosGenNHibernate.Exceptions;
using System.Collections.Generic;

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

            userCADMock.Setup(mock => mock.GetTipsterById(It.IsAny<int>())).Returns(nuevo);

            TipsterCEN tipster = new TipsterCEN(userCADMock.Object);

            TipsterEN actual = tipster.GetTipsterById(1);

            Assert.AreEqual(actual.Alias, "Macareno");
            Assert.AreEqual(actual.Password, "Hola12345");

            userCADMock.Verify(mock => mock.GetTipsterById(It.IsAny<int>()), Times.Once);

        }

        [TestMethod]
        public void IncorrectLoginTest()
        {
            var userCADMock = new Mock<ITipsterCAD>();

            TipsterEN nuevo = new TipsterEN();
            nuevo.Alias = "Macareno";
            nuevo.Password = "Hola12345";

            userCADMock.Setup(mock => mock.GetTipsterById(It.IsAny<int>())).Returns(nuevo);

            TipsterCEN tipster = new TipsterCEN(userCADMock.Object);

            TipsterEN actual = tipster.GetTipsterById(1);

            Assert.AreEqual(actual.Alias, "Macareno");
            Assert.AreNotEqual(actual.Password, "Macareno");

            userCADMock.Verify(mock => mock.GetTipsterById(It.IsAny<int>()), Times.Once);

        }

        [TestMethod]
        public void ChangePasswordTest()
        {
            var userCADMock = new Mock<ITipsterCAD>();

            TipsterEN nuevo = new TipsterEN();
            nuevo.Alias = "Macareno";
            nuevo.Password = "Adios12345";

            userCADMock.Setup(mock => mock.GetTipsterById(It.IsAny<int>())).Returns(nuevo);

            TipsterCEN tipster = new TipsterCEN(userCADMock.Object);
            tipster.ModifyTipster(1, new TimeSpan(), new TimeSpan(), "Macareno", "hola@gmail.com", "Adios12345", false, 0);
            TipsterEN actual = tipster.GetTipsterById(1);

            Assert.AreEqual(actual.Alias, "Macareno");
            Assert.AreEqual(actual.Password, "Adios12345");

            userCADMock.Verify(mock => mock.GetTipsterById(It.IsAny<int>()), Times.Once);
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

            userCADMock.Setup(mock => mock.GetTipsterById(It.IsAny<int>())).Returns(nuevo);

            TipsterCEN tipster = new TipsterCEN(userCADMock.Object);
            tipster.BecomePremium(1, 1.5);
            TipsterEN actual = tipster.GetTipsterById(1);

            Assert.IsTrue(actual.Premium);
            Assert.AreEqual(actual.Subscription_fee, actual.Subscription_fee);

            userCADMock.Verify(mock => mock.GetTipsterById(It.IsAny<int>()), Times.AtMost(2));

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

            userCADMock.Setup(mock => mock.GetTipsterById(It.IsAny<int>())).Returns(nuevo);
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

            userCADMock.Verify(mock => mock.GetTipsterById(It.IsAny<int>()), Times.Once);
            userCADMock.Verify(mock => mock.ModifyTipster(It.IsAny<TipsterEN>()), Times.Once);

        }

       /** [TestMethod]
        public void GetFollowsTest()
        {
            var tipsterCADMock = new Mock<ITipsterCAD>();

            tipsterCADMock.Setup(mock => mock.GetFollows(It.IsAny<int>())).Returns(It.IsAny<List<TipsterEN>>());

            TipsterCEN tipsterCEN = new TipsterCEN(tipsterCADMock.Object);
            List<int> follows = new List<int>();
            follows.Add(2);
            follows.Add(3);

            try
            {
                tipsterCEN.AddFollow(1, follows);
                tipsterCEN.GetFollows(1);
            }
            catch (Exception ex)
            {
                Assert.Fail("Should not throw exception");
            }

            tipsterCADMock.Verify(mock => mock.GetFollows(It.IsAny<int>()), Times.Once);

        }

        [TestMethod]
        public void GetFollowsModelExceptionTest()
        {
            var tipsterCADMock = new Mock<ITipsterCAD>();

            tipsterCADMock.Setup(mock => mock.GetFollows(It.IsAny<int>())).Throws(new ModelException());

            TipsterCEN tipsterCEN = new TipsterCEN(tipsterCADMock.Object);
            List<int> follows = new List<int>();
            follows.Add(2);
            follows.Add(3);

            try
            {
                tipsterCEN.AddFollow(1, follows);
                tipsterCEN.GetFollows(1);
                Assert.Fail("Should throw model exception");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ModelException));
            }

            tipsterCADMock.Verify(mock => mock.GetFollows(It.IsAny<int>()), Times.Once);

        }

        [TestMethod]
        public void GetFollowsDataLayerExceptionTest()
        {
            var tipsterCADMock = new Mock<ITipsterCAD>();

            tipsterCADMock.Setup(mock => mock.GetFollows(It.IsAny<int>())).Throws(new DataLayerException("Error in TipsterCAD."));

            TipsterCEN tipsterCEN = new TipsterCEN(tipsterCADMock.Object);
            List<int> follows = new List<int>();
            follows.Add(2);
            follows.Add(3);

            try
            {
                tipsterCEN.AddFollow(1, follows);
                tipsterCEN.GetFollows(1);
                Assert.Fail("Should throw data layer exception");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(DataLayerException));
                Assert.AreEqual("Error in TipsterCAD.", ex.Message);
            }

            tipsterCADMock.Verify(mock => mock.GetFollows(It.IsAny<int>()), Times.Once);

        }

        [TestMethod]
        public void DeleteFollowsTest()
        {
            var tipsterCADMock = new Mock<ITipsterCAD>();

            tipsterCADMock.Setup(mock => mock.GetFollows(It.IsAny<int>())).Returns(It.IsAny<List<TipsterEN>>());

            TipsterCEN tipsterCEN = new TipsterCEN(tipsterCADMock.Object);
            List<int> follows = new List<int>();
            follows.Add(2);
            follows.Add(3);

            List<int> deletes = new List<int>();
            follows.Add(2);

            try
            {
                tipsterCEN.AddFollow(1, follows);
                tipsterCEN.DeleteFollow(1, deletes);
                tipsterCEN.GetFollows(1);
            }
            catch (Exception ex)
            {
                Assert.Fail("Should not throw exception");
            }

            tipsterCADMock.Verify(mock => mock.GetFollows(It.IsAny<int>()), Times.Once);

        }

        [TestMethod]
        public void DeleteFollowsModelExceptionTest()
        {
            var tipsterCADMock = new Mock<ITipsterCAD>();

            tipsterCADMock.Setup(mock => mock.DeleteFollow(It.IsAny<int>(), It.IsAny<List<int>>())).Throws(new ModelException());

            TipsterCEN tipsterCEN = new TipsterCEN(tipsterCADMock.Object);
            List<int> follows = new List<int>();
            follows.Add(2);
            follows.Add(3);

            List<int> deletes = new List<int>();
            follows.Add(2);

            try
            {
                tipsterCEN.AddFollow(1, follows);
                tipsterCEN.DeleteFollow(1, deletes);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ModelException));
            }

            tipsterCADMock.Verify(mock => mock.DeleteFollow(It.IsAny<int>(), It.IsAny<List<int>>()), Times.Once);

        }

       /** [TestMethod]
        public void GetFollowersTest()
        {
            var tipsterCADMock = new Mock<ITipsterCAD>();

            tipsterCADMock.Setup(mock => mock.GetFollowers(It.IsAny<int>())).Returns(It.IsAny<List<TipsterEN>>());

            TipsterCEN tipsterCEN = new TipsterCEN(tipsterCADMock.Object);
            List<int> followers = new List<int>();
            followers.Add(2);
            followers.Add(3);

            try
            {
                tipsterCEN.AddFollower(1, followers);
                tipsterCEN.GetFollowers(1);
            }
            catch (Exception ex)
            {
                Assert.Fail("Should not throw exception");
            }

            tipsterCADMock.Verify(mock => mock.GetFollowers(It.IsAny<int>()), Times.Once);

        }

        [TestMethod]
        public void GetFollowersModelExceptionTest()
        {
            var tipsterCADMock = new Mock<ITipsterCAD>();

            tipsterCADMock.Setup(mock => mock.GetFollowers(It.IsAny<int>())).Throws(new ModelException());

            TipsterCEN tipsterCEN = new TipsterCEN(tipsterCADMock.Object);
            List<int> followers = new List<int>();
            followers.Add(2);
            followers.Add(3);

            try
            {
                tipsterCEN.AddFollower(1, followers);
                tipsterCEN.GetFollowers(1);
                Assert.Fail("Should throw model exception");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ModelException));
            }

            tipsterCADMock.Verify(mock => mock.GetFollowers(It.IsAny<int>()), Times.Once);

        }**/

        /**  [TestMethod]
        public void GettingStatsByMonthShouldThrowModelException()
         {
             var mockCADtipster = new Mock<ITipsterCAD>();

             mockCADtipster.Setup(mock => mock.GetStatsByMonth(It.IsAny<DateTime>())).Throws(new ModelException());

             TipsterCEN tipsterCEN = new TipsterCEN(mockCADtipster.Object);
             try
             {
                 tipsterCEN.GetStatsByMonth(It.IsAny<DateTime>());
                 Assert.Fail("Should throw model exception");
             }
             catch (Exception actualException)
             {
                 Assert.IsInstanceOfType(actualException, typeof(ModelException));
             }
         }**/

    }
}
