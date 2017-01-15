using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PickadosGenNHibernate.CAD.Pickados;
using System.Collections.Generic;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.Exceptions;

namespace UnitTest
{
    [TestClass]
    public class CompetitionTest
    {
        [TestMethod]
        public void GettingCompetitionByPlaceOk()
        {
            var mockCADCompetition = new Mock<ICompetitionCAD>();

            mockCADCompetition.Setup(mock => mock.GetCompetitionsByPlace(It.IsAny<string>())).Returns(It.IsAny<List<CompetitionEN>>());

            CompetitionCEN competitionCEN = new CompetitionCEN(mockCADCompetition.Object);

            try{
                competitionCEN.GetCompetitionsByPlace(It.IsAny<string>());
            }catch(Exception ex)
            {
                Assert.Fail("Should not throw exception");
            }

            mockCADCompetition.Verify(mock => mock.GetCompetitionsByPlace(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void GettingCompetitionByPlaceShouldThrowModelException()
        {
            var mockCADCompetition = new Mock<ICompetitionCAD>();

            mockCADCompetition.Setup(mock => mock.GetCompetitionsByPlace(It.IsAny<string>())).Throws(new ModelException());
               
            CompetitionCEN competitionCEN = new CompetitionCEN(mockCADCompetition.Object);
            try
            {
                competitionCEN.GetCompetitionsByPlace(It.IsAny<string>());
                Assert.Fail("Should throw model exception");
            }
            catch (Exception actualException)
            {
                Assert.IsInstanceOfType(actualException, typeof(ModelException));
            }
            mockCADCompetition.Verify(mock => mock.GetCompetitionsByPlace(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void GettingCompetitionByPlaceShouldThrowDataLayerException()
        {
            var mockCADCompetition = new Mock<ICompetitionCAD>();

            mockCADCompetition.Setup(mock => mock.GetCompetitionsByPlace(It.IsAny<string>())).Throws(new DataLayerException("Error in CompetitionCAD."));

            CompetitionCEN competitionCEN = new CompetitionCEN(mockCADCompetition.Object);
            try
            {
                competitionCEN.GetCompetitionsByPlace(It.IsAny<string>());
                Assert.Fail("Should throw model exception");
            }
            catch (Exception actualException)
            {
                Assert.IsInstanceOfType(actualException, typeof(DataLayerException));
                Assert.AreEqual("Error in CompetitionCAD.", actualException.Message);
            }
            mockCADCompetition.Verify(mock => mock.GetCompetitionsByPlace(It.IsAny<string>()), Times.Once);
        }
    }
}
