using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickadosGenNHibernate.CEN.Pickados;
using Moq;
using PickadosGenNHibernate.EN.Pickados;
using System.Collections.Generic;
using PickadosGenNHibernate.Enumerated.Pickados;
using PickadosGenNHibernate.CAD.Pickados;
using PickadosGenNHibernate.CP.Pickados;

namespace UnitTest
{

    [TestClass]
    public class VerifyPostTest
    {
        /*
        [TestMethod]
        public void VerifyingPost()
        {

            //Create mocks
            var postCADMock = new Mock<IPostCAD>();
            var tipsterCADMock = new Mock<ITipsterCAD>();
            var statsCADMock = new Mock<IStatsCAD>();

            //Creating post with pickresult=won !
            PostEN postEN = new PostEN();
            PickEN pickEN = new PickEN();
            pickEN.PickResult = PickResultEnum.won;

            IList<PickEN> picks = new List<PickEN>();
            picks.Add(pickEN);
            postEN.Pick = picks;
            postEN.TotalOdd = 2;
            postEN.Stake = 1;

            TipsterEN tipsterEN = new TipsterEN();

            postEN.Tipster = tipsterEN;

            StatsEN statsEN = new StatsEN();

            postCADMock.Setup(mock => mock.GetPostById(It.IsAny<int>())).Returns(postEN);
            tipsterCADMock.Setup(mock => mock.GetTipsterById(It.IsAny<int>())).Returns(tipsterEN);
            statsCADMock.Setup(mock => mock.NewMonthlyStats(It.IsAny<StatsEN>())).Returns(1);
            statsCADMock.Setup(mock => mock.GetStatById(It.IsAny<int>())).Returns(statsEN);

            
            PostCEN postCEN = new PostCEN(postCADMock.Object);
            TipsterCEN tipsterCEN = new TipsterCEN(tipsterCADMock.Object);
            StatsCEN statsCEN = new StatsCEN(statsCADMock.Object);


            try
            {
               // postCEN.VerifyPost(1, postCEN, tipsterCEN, statsCEN);
            }
            catch (Exception ex)
            {
                Assert.Fail("Should not throw exception");
            }



           tipsterCADMock.Verify(mock => mock.GetTipsterById(It.IsAny<int>()), Times.Once);
           postCADMock.Verify(mock => mock.GetPostById(It.IsAny<int>()), Times.Once);
           postCADMock.Verify(mock => mock.GetPostById(It.IsAny<int>()), Times.Once);
        }
        */
        [TestMethod]
        public void UpdateStatsGivenPostWithWonPick()
        {
            //Creating post with pickresult=won !
            PostEN postEN = new PostEN();
            PostCEN postCEN = new PostCEN();
            PickEN pickEN = new PickEN();
            pickEN.PickResult = PickResultEnum.won;
            PostCP postCP = new PostCP();


            IList<PickEN> picks = new List<PickEN>();
            picks.Add(pickEN);
            postEN.Pick = picks;
            postEN.TotalOdd = 2;
            postEN.Stake = 1;
            //Create mocks

            StatsEN stats = postCP.updateStats(new StatsEN(), postEN);
            Assert.AreEqual(stats.TotalPicks, 1);
            Assert.AreEqual(stats.TotalStaked, 1);
            Assert.AreEqual(stats.OddAverage, 2);
            Assert.AreEqual(stats.Yield, 100);
            Assert.AreEqual(stats.Benefit, 1);

        }
    }
}
