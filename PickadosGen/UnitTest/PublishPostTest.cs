using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickadosGenNHibernate.CEN.Pickados;
using Moq;
using PickadosGenNHibernate.EN.Pickados;
using System.Collections.Generic;
using PickadosGenNHibernate.Enumerated.Pickados;
using PickadosGenNHibernate.CAD.Pickados;

namespace UnitTest
{
    [TestClass]
    public class PublishPostTest
    {
        /*
        [TestMethod]
        public void PublishPostOkTest()
        {
            //Create mocks
            var postCADMock = new Mock<IPostCAD>();
            var pickCADMock = new Mock<IPickCAD>();

            //Prepare data to be returned by mocks
            List<int> pick_ids = new List<int>();
            pick_ids.Add(1);
            PickEN pick = new PickEN();
            Event_EN eventPick = new Event_EN();
            eventPick.Date = new DateTime(2018, 1, 16, 15, 0, 0);
            pick.Event_rel = eventPick;
            List<PickEN> picks = new List<PickEN>();
            picks.Add(pick);
            PostEN expectedPost = new PostEN();
            expectedPost.Pick = picks;

            //Setup mock methods
            postCADMock.Setup(mock => mock.NewPost(It.IsAny<PostEN>())).Returns(1);
            postCADMock.Setup(mock => mock.GetPostById(It.IsAny<int>())).Returns(expectedPost);
            pickCADMock.Setup(mock => mock.GetPickById(It.IsAny<int>())).Returns(pick);

            PostCEN postCEN = new PostCEN(postCADMock.Object);
            PickCEN pickCEN = new PickCEN(pickCADMock.Object);

            PostEN actualPost = postCEN.PublishPost(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<Double>(), It.IsAny<string>(), It.IsAny<bool>(), pick_ids, It.IsAny<int>(), It.IsAny<double>(), It.IsAny<PickResultEnum>(), pickCEN);

            //Test method (check if picks are equal)
            Assert.AreEqual(expectedPost.Pick, actualPost.Pick);
            Assert.IsNotNull(expectedPost);

            //Verify mocks
            postCADMock.Verify(mock => mock.NewPost(It.IsAny<PostEN>()), Times.Once);
            postCADMock.Verify(mock => mock.GetPostById(It.IsAny<int>()), Times.Once);
            pickCADMock.Verify(mock => mock.GetPickById(It.IsAny<int>()), Times.AtLeastOnce);

        }

        [TestMethod]
        public void PublishPostFailWhenInvalidDate()
        {

            //Create mocks
            var postCADMock = new Mock<IPostCAD>();
            var pickCADMock = new Mock<IPickCAD>();

            //Prepare data to be returned by mocks
            List<int> pick_ids = new List<int>();
            pick_ids.Add(1);
            PickEN pick = new PickEN();
            Event_EN eventPick = new Event_EN();
            eventPick.Date = new DateTime(2016, 1, 16, 15, 0, 0);
            pick.Event_rel = eventPick;
            List<PickEN> picks = new List<PickEN>();
            picks.Add(pick);
            PostEN expectedPost = null;

            //Setup mock methods
            postCADMock.Setup(mock => mock.NewPost(It.IsAny<PostEN>())).Returns(1);
            postCADMock.Setup(mock => mock.GetPostById(It.IsAny<int>())).Returns(expectedPost);
            pickCADMock.Setup(mock => mock.GetPickById(It.IsAny<int>())).Returns(pick);

            PostCEN postCEN = new PostCEN(postCADMock.Object);
            PickCEN pickCEN = new PickCEN(pickCADMock.Object);

            PostEN actualPost = postCEN.PublishPost(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<Double>(), It.IsAny<string>(), It.IsAny<bool>(), pick_ids, It.IsAny<int>(), It.IsAny<double>(), It.IsAny<PickResultEnum>(), pickCEN);

            //Test method (check if picks are equal)
            Assert.IsNull(expectedPost);
            //Verify mocks
            postCADMock.Verify(mock => mock.NewPost(It.IsAny<PostEN>()), Times.Never);
            postCADMock.Verify(mock => mock.GetPostById(It.IsAny<int>()), Times.Never);
            pickCADMock.Verify(mock => mock.GetPickById(It.IsAny<int>()), Times.AtLeastOnce);

        }
        */
    }
}
