using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickadosGenNHibernate.CAD.Pickados;
using Moq;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.Exceptions;

namespace UnitTest
{
    /// <summary>
    /// Descripción resumida de MatchTest
    /// </summary>
    [TestClass]
    public class MatchTest
    {
        [TestMethod]
        public void GetMatchByLocalTeamOkTest()
        {
            var matchMock = new Mock<IMatchCAD>();

            matchMock.Setup(mock => mock.GetMatchByLocalTeam(It.IsAny<int>())).Returns(It.IsAny<List<MatchEN>>());

            MatchCEN matchCEN = new MatchCEN(matchMock.Object);
            
            try
            {
                matchCEN.GetMatchByLocalTeam(12345);
            }
            catch (Exception ex)
            {
                Assert.Fail("Should not throw exception");
            }

            matchMock.Verify(mock => mock.GetMatchByLocalTeam(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void GetMatchByLocalTeamModelExceptionTest()
        {
            var matchMock = new Mock<IMatchCAD>();

            matchMock.Setup(mock => mock.GetMatchByLocalTeam(It.IsAny<int>())).Throws(new ModelException());

            MatchCEN matchCEN = new MatchCEN(matchMock.Object);

            try
            {
                matchCEN.GetMatchByLocalTeam(123456);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ModelException));
            }

            matchMock.Verify(mock => mock.GetMatchByLocalTeam(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void GetMatchByLocalTeamDataLayerExceptionTest()
        {
            var matchMock = new Mock<IMatchCAD>();

            matchMock.Setup(mock => mock.GetMatchByLocalTeam(It.IsAny<int>())).Throws(new DataLayerException());

            MatchCEN matchCEN = new MatchCEN(matchMock.Object);

            try
            {
                matchCEN.GetMatchByLocalTeam(123456);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(DataLayerException));
            }

            matchMock.Verify(mock => mock.GetMatchByLocalTeam(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void GetMatchByVisitantTeamOkTest()
        {
            var matchMock = new Mock<IMatchCAD>();

            matchMock.Setup(mock => mock.GetMatchByVisistantTeam(It.IsAny<int>())).Returns(It.IsAny<List<MatchEN>>());

            MatchCEN matchCEN = new MatchCEN(matchMock.Object);

            try
            {
                matchCEN.GetMatchByVisistantTeam(12345);
            }
            catch (Exception ex)
            {
                Assert.Fail("Should not throw exception");
            }

            matchMock.Verify(mock => mock.GetMatchByVisistantTeam(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void GetMatchByVisistantTeamModelExceptionTest()
        {
            var matchMock = new Mock<IMatchCAD>();

            matchMock.Setup(mock => mock.GetMatchByVisistantTeam(It.IsAny<int>())).Throws(new ModelException());

            MatchCEN matchCEN = new MatchCEN(matchMock.Object);

            try
            {
                matchCEN.GetMatchByVisistantTeam(123456);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ModelException));
            }

            matchMock.Verify(mock => mock.GetMatchByVisistantTeam(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void GetMatchByVisistantTeamDataLayerExceptionTest()
        {
            var matchMock = new Mock<IMatchCAD>();

            matchMock.Setup(mock => mock.GetMatchByVisistantTeam(It.IsAny<int>())).Throws(new DataLayerException());

            MatchCEN matchCEN = new MatchCEN(matchMock.Object);

            try
            {
                matchCEN.GetMatchByVisistantTeam(123456);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(DataLayerException));
            }

            matchMock.Verify(mock => mock.GetMatchByVisistantTeam(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void GetMatchByCompetitionOkTest()
        {
            var matchMock = new Mock<IMatchCAD>();

            matchMock.Setup(mock => mock.GetMatchByCompetition(It.IsAny<int>())).Returns(It.IsAny<List<MatchEN>>());

            MatchCEN matchCEN = new MatchCEN(matchMock.Object);

            try
            {
                matchCEN.GetMatchByCompetition(14725);
            }
            catch (Exception ex)
            {
                Assert.Fail("Should not throw exception");
            }

            matchMock.Verify(mock => mock.GetMatchByCompetition(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void GetMatchByCompetitionModelExceptionTest()
        {
            var matchMock = new Mock<IMatchCAD>();

            matchMock.Setup(mock => mock.GetMatchByCompetition(It.IsAny<int>())).Throws(new ModelException());

            MatchCEN matchCEN = new MatchCEN(matchMock.Object);

            try
            {
                matchCEN.GetMatchByCompetition(14725);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ModelException));
            }

            matchMock.Verify(mock => mock.GetMatchByCompetition(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void GetMatchByCompetitionDataLayerExceptionTest()
        {
            var matchMock = new Mock<IMatchCAD>();

            matchMock.Setup(mock => mock.GetMatchByCompetition(It.IsAny<int>())).Throws(new DataLayerException());

            MatchCEN matchCEN = new MatchCEN(matchMock.Object);

            try
            {
                matchCEN.GetMatchByCompetition(14725);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(DataLayerException));
            }

            matchMock.Verify(mock => mock.GetMatchByCompetition(It.IsAny<int>()), Times.Once);
        }
    }
}
