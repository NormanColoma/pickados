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
        public void GetMatchByTeamOkTest()
        {
            var matchMock = new Mock<IMatchCAD>();

            matchMock.Setup(mock => mock.GetMatchByTeam(It.IsAny<string>())).Returns(It.IsAny<List<MatchEN>>());

            MatchCEN matchCEN = new MatchCEN(matchMock.Object);
            
            try
            {
                matchCEN.GetMatchByTeam("Eibar");
            }
            catch (Exception ex)
            {
                Assert.Fail("Should not throw exception");
            }

            matchMock.Verify(mock => mock.GetMatchByTeam(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void GetMatchByTeamModelExceptionTest()
        {
            var matchMock = new Mock<IMatchCAD>();

            matchMock.Setup(mock => mock.GetMatchByTeam(It.IsAny<string>())).Throws(new ModelException());

            MatchCEN matchCEN = new MatchCEN(matchMock.Object);

            try
            {
                matchCEN.GetMatchByTeam("Eibar");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ModelException));
            }

            matchMock.Verify(mock => mock.GetMatchByTeam(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void GetMatchByTeamDataLayerExceptionTest()
        {
            var matchMock = new Mock<IMatchCAD>();

            matchMock.Setup(mock => mock.GetMatchByTeam(It.IsAny<string>())).Throws(new DataLayerException());

            MatchCEN matchCEN = new MatchCEN(matchMock.Object);

            try
            {
                matchCEN.GetMatchByTeam("Eibar");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(DataLayerException));
            }

            matchMock.Verify(mock => mock.GetMatchByTeam(It.IsAny<string>()), Times.Once);
        }

        /**[TestMethod]
        public void GetMatchByCompetitionOkTest()
        {
            var matchMock = new Mock<IMatchCAD>();

            matchMock.Setup(mock => mock.GetMatchByCompetition(It.IsAny<string>())).Returns(It.IsAny<List<MatchEN>>());

            MatchCEN matchCEN = new MatchCEN(matchMock.Object);

            try
            {
                matchCEN.GetMatchByCompetition("Champions League");
            }
            catch (Exception ex)
            {
                Assert.Fail("Should not throw exception");
            }

            matchMock.Verify(mock => mock.GetMatchByCompetition(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void GetMatchByCompetitionModelExceptionTest()
        {
            var matchMock = new Mock<IMatchCAD>();

            matchMock.Setup(mock => mock.GetMatchByCompetition(It.IsAny<string>())).Throws(new ModelException());

            MatchCEN matchCEN = new MatchCEN(matchMock.Object);

            try
            {
                matchCEN.GetMatchByCompetition("Champions League");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ModelException));
            }

            matchMock.Verify(mock => mock.GetMatchByCompetition(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void GetMatchByCompetitionDataLayerExceptionTest()
        {
            var matchMock = new Mock<IMatchCAD>();

            matchMock.Setup(mock => mock.GetMatchByCompetition(It.IsAny<string>())).Throws(new DataLayerException());

            MatchCEN matchCEN = new MatchCEN(matchMock.Object);

            try
            {
                matchCEN.GetMatchByCompetition("Champions League");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(DataLayerException));
            }

            matchMock.Verify(mock => mock.GetMatchByCompetition(It.IsAny<string>()), Times.Once);
        }**/
    }
}
