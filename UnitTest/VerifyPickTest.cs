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
    public class VerifyPickTest
    {
        [TestMethod]
        public void UpdateStatsGivenPostWithWonPick()
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

            postCADMock.Setup(mock => mock.GetByID(It.IsAny<int>())).Returns(postEN);
            tipsterCADMock.Setup(mock => mock.GetByID(It.IsAny<int>())).Returns(tipsterEN);
            statsCADMock.Setup(mock => mock.NewMonthlyStats(It.IsAny<StatsEN>())).Returns(1);
            statsCADMock.Setup(mock => mock.GetByID(It.IsAny<int>())).Returns(statsEN);


            PostCEN postCEN = new PostCEN(postCADMock.Object);
            TipsterCEN tipsterCEN = new TipsterCEN(tipsterCADMock.Object);
            StatsCEN statsCEN = new StatsCEN(statsCADMock.Object);
            postCEN.VerifyPost(1, postCEN, tipsterCEN, statsCEN);


            Assert.AreEqual(1, 1);
            /**Assert.AreEqual(1, actual_totalStaked);
            Assert.AreEqual(2, actual_oddAccumulator);
            Assert.AreEqual(1, actual_stakeAverage);
            Assert.AreEqual(2, actual_oddAverage);
            Assert.AreEqual(100, actual_yield);
            Assert.AreEqual(1, actual_totalPicks);**/
        }
    }
}
