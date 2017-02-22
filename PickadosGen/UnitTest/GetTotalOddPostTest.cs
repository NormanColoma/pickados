using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PickadosGenNHibernate.CAD.Pickados;
using PickadosGenNHibernate.EN.Pickados;
using System.Collections.Generic;
using PickadosGenNHibernate.CEN.Pickados;

namespace UnitTest
{
    [TestClass]
    public class GetTotalOddPostTest
    {
        [TestMethod]
        public void GetTotalOddFromPostIfExists()
        {
            //Creating moicks
            var postCADMock = new Mock<IPostCAD>();

            //Preparing data to be returned by mocks
            PostEN post = new PostEN();
            List<PickEN> picks = new List<PickEN>();
            PickEN pick = new PickEN();
            pick.Odd = 10;
            PickEN pick2 = new PickEN();
            pick2.Odd = 10;
            picks.Add(pick);
            picks.Add(pick2);
            post.Pick = picks;

            //Setting up mocks
            postCADMock.Setup(mock => mock.GetPostById(It.IsAny<int>())).Returns(post);

            //Testing method 
            PostCEN postCEN = new PostCEN(postCADMock.Object);
            double expected_odds = 20;
            double actual_odds = postCEN.GetTotalOdd(It.IsAny<int>());
            Assert.AreEqual(expected_odds, actual_odds);
        }

        [TestMethod]
        public void GetTotalOddFromPostIfNotExists()
        {
            //Creating moicks
            var postCADMock = new Mock<IPostCAD>();

            //Preparing data to be returned by mocks
            PostEN post = new PostEN();

            //Setting up mocks
            postCADMock.Setup(mock => mock.GetPostById(It.IsAny<int>())).Returns(post);

            //Testing method 
            PostCEN postCEN = new PostCEN(postCADMock.Object);
            double expected_odds = 0;
            double actual_odds = postCEN.GetTotalOdd(It.IsAny<int>());
            Assert.AreEqual(expected_odds, actual_odds);

            //Testing CI for features branches
        }

    }
}