using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickadosGenNHibernate.CEN.Pickados;
using Moq;
using PickadosGenNHibernate.CAD.Pickados;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.Exceptions;

namespace UnitTest
{
    /// <summary>
    /// Descripción resumida de TeamTest
    /// </summary>
    [TestClass]
    public class PlayerTest
    {
        public PlayerTest()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la serie de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void JoinClubTeamOkTest()
        {
            //Create mocks
            var playerMock = new Mock<IPlayerCAD>();
            playerMock.Setup(mock => mock.JoinClubTeam(It.IsAny<int>(), It.IsAny<int>()));

            PlayerCEN playerCEN = new PlayerCEN(playerMock.Object);

            try {
                playerCEN.JoinClubTeam(It.IsAny<int>(), It.IsAny<int>());
            }
            catch(Exception ex) {
                Assert.Fail("Should not throw exception");
            }

            playerMock.Verify(mock => mock.JoinClubTeam(It.IsAny<int>(), It.IsAny<int>()));
        }

        [TestMethod]
        public void JoinClubTeamModelExceptionTest()
        {
            //Create mocks
            var playerMock = new Mock<IPlayerCAD>();
            playerMock.Setup(mock => mock.JoinClubTeam(It.IsAny<int>(), It.IsAny<int>())).Throws(new ModelException());

            PlayerCEN playerCEN = new PlayerCEN(playerMock.Object);

            try
            {
                playerCEN.JoinClubTeam(It.IsAny<int>(), It.IsAny<int>());
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ModelException));
            }

            playerMock.Verify(mock => mock.JoinClubTeam(It.IsAny<int>(), It.IsAny<int>()));
        }

        [TestMethod]
        public void JoinClubTeamDataLayerExceptionTest()
        {
            //Create mocks
            var playerMock = new Mock<IPlayerCAD>();
            playerMock.Setup(mock => mock.JoinClubTeam(It.IsAny<int>(), It.IsAny<int>())).Throws(new DataLayerException("Error in PlayerCAD."));

            PlayerCEN playerCEN = new PlayerCEN(playerMock.Object);

            try
            {
                playerCEN.JoinClubTeam(It.IsAny<int>(), It.IsAny<int>());
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(DataLayerException));
                Assert.AreEqual("Error in PlayerCAD.", ex.Message);
            }

            playerMock.Verify(mock => mock.JoinClubTeam(It.IsAny<int>(), It.IsAny<int>()));
        }

        [TestMethod]
        public void UnlinkClubTeamOkTest()
        {
            //Create mocks
            var playerMock = new Mock<IPlayerCAD>();
            playerMock.Setup(mock => mock.UnlinkClubTeam(It.IsAny<int>(), It.IsAny<int>()));

            PlayerCEN playerCEN = new PlayerCEN(playerMock.Object);

            try
            {
                playerCEN.UnlinkClubTeam(It.IsAny<int>(), It.IsAny<int>());
            }
            catch (Exception ex)
            {
                Assert.Fail("Should not throw exception");
            }

            playerMock.Verify(mock => mock.UnlinkClubTeam(It.IsAny<int>(), It.IsAny<int>()));
        }

        [TestMethod]
        public void UnlinkClubTeamModelExceptionTest()
        {
            //Create mocks
            var playerMock = new Mock<IPlayerCAD>();
            playerMock.Setup(mock => mock.UnlinkClubTeam(It.IsAny<int>(), It.IsAny<int>())).Throws(new ModelException());

            PlayerCEN playerCEN = new PlayerCEN(playerMock.Object);

            try
            {
                playerCEN.UnlinkClubTeam(It.IsAny<int>(), It.IsAny<int>());
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ModelException));
            }

            playerMock.Verify(mock => mock.UnlinkClubTeam(It.IsAny<int>(), It.IsAny<int>()));
        }

        [TestMethod]
        public void UnlinkClubTeamDataLayerExceptionTest()
        {
            //Create mocks
            var playerMock = new Mock<IPlayerCAD>();
            playerMock.Setup(mock => mock.UnlinkClubTeam(It.IsAny<int>(), It.IsAny<int>())).Throws(new DataLayerException("Error in PlayerCAD."));

            PlayerCEN playerCEN = new PlayerCEN(playerMock.Object);

            try
            {
                playerCEN.UnlinkClubTeam(It.IsAny<int>(), It.IsAny<int>());
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(DataLayerException));
                Assert.AreEqual("Error in PlayerCAD.", ex.Message);
            }

            playerMock.Verify(mock => mock.UnlinkClubTeam(It.IsAny<int>(), It.IsAny<int>()));
        }

        [TestMethod]
        public void JoinNationalTeamOkTest()
        {
            //Create mocks
            var playerMock = new Mock<IPlayerCAD>();
            playerMock.Setup(mock => mock.JoinNationalTeam(It.IsAny<int>(), It.IsAny<int>()));

            PlayerCEN playerCEN = new PlayerCEN(playerMock.Object);

            try
            {
                playerCEN.JoinNationalTeam(It.IsAny<int>(), It.IsAny<int>());
            }
            catch (Exception ex)
            {
                Assert.Fail("Should not throw exception");
            }

            playerMock.Verify(mock => mock.JoinNationalTeam(It.IsAny<int>(), It.IsAny<int>()));
        }

        [TestMethod]
        public void JoinNationalTeamModelExceptionTest()
        {
            //Create mocks
            var playerMock = new Mock<IPlayerCAD>();
            playerMock.Setup(mock => mock.JoinNationalTeam(It.IsAny<int>(), It.IsAny<int>())).Throws(new ModelException());

            PlayerCEN playerCEN = new PlayerCEN(playerMock.Object);

            try
            {
                playerCEN.JoinNationalTeam(It.IsAny<int>(), It.IsAny<int>());
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ModelException));
            }

            playerMock.Verify(mock => mock.JoinNationalTeam(It.IsAny<int>(), It.IsAny<int>()));
        }

        [TestMethod]
        public void JoinNationalTeamDataLayerExceptionTest()
        {
            //Create mocks
            var playerMock = new Mock<IPlayerCAD>();
            playerMock.Setup(mock => mock.JoinNationalTeam(It.IsAny<int>(), It.IsAny<int>())).Throws(new DataLayerException("Error in PlayerCAD."));

            PlayerCEN playerCEN = new PlayerCEN(playerMock.Object);

            try
            {
                playerCEN.JoinNationalTeam(It.IsAny<int>(), It.IsAny<int>());
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(DataLayerException));
                Assert.AreEqual("Error in PlayerCAD.", ex.Message);
            }

            playerMock.Verify(mock => mock.JoinNationalTeam(It.IsAny<int>(), It.IsAny<int>()));
        }

        [TestMethod]
        public void UnlinkNationalTeamOkTest()
        {
            //Create mocks
            var playerMock = new Mock<IPlayerCAD>();
            playerMock.Setup(mock => mock.UnlinkNationalTeam(It.IsAny<int>(), It.IsAny<int>()));

            PlayerCEN playerCEN = new PlayerCEN(playerMock.Object);

            try
            {
                playerCEN.UnlinkNationalTeam(It.IsAny<int>(), It.IsAny<int>());
            }
            catch (Exception ex)
            {
                Assert.Fail("Should not throw exception");
            }

            playerMock.Verify(mock => mock.UnlinkNationalTeam(It.IsAny<int>(), It.IsAny<int>()));
        }

        [TestMethod]
        public void UnlinkNationalTeamModelExceptionTest()
        {
            //Create mocks
            var playerMock = new Mock<IPlayerCAD>();
            playerMock.Setup(mock => mock.UnlinkNationalTeam(It.IsAny<int>(), It.IsAny<int>())).Throws(new ModelException());

            PlayerCEN playerCEN = new PlayerCEN(playerMock.Object);

            try
            {
                playerCEN.UnlinkNationalTeam(It.IsAny<int>(), It.IsAny<int>());
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ModelException));
            }

            playerMock.Verify(mock => mock.UnlinkNationalTeam(It.IsAny<int>(), It.IsAny<int>()));
        }

        [TestMethod]
        public void UnlinkNationalTeamDataLayerExceptionTest()
        {
            //Create mocks
            var playerMock = new Mock<IPlayerCAD>();
            playerMock.Setup(mock => mock.UnlinkNationalTeam(It.IsAny<int>(), It.IsAny<int>())).Throws(new DataLayerException("Error in PlayerCAD."));

            PlayerCEN playerCEN = new PlayerCEN(playerMock.Object);

            try
            {
                playerCEN.UnlinkNationalTeam(It.IsAny<int>(), It.IsAny<int>());
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(DataLayerException));
                Assert.AreEqual("Error in PlayerCAD.", ex.Message);
            }

            playerMock.Verify(mock => mock.UnlinkNationalTeam(It.IsAny<int>(), It.IsAny<int>()));
        }

        [TestMethod]
        public void GetPlayersFromTeamTest()
        {
            //Create mocks
            var playerMock = new Mock<IPlayerCAD>();
            List<PlayerEN> jugadores = new List<PlayerEN>();
            PlayerEN nuevo = new PlayerEN();
            nuevo.Name = "Pepe";
            jugadores.Add(nuevo);

            playerMock.Setup(mock => mock.GetPlayersByTeam(It.IsAny<int>())).Returns(jugadores);

            PlayerCEN playerCEN = new PlayerCEN(playerMock.Object);

            IList<PlayerEN> otro = playerCEN.GetPlayersByTeam(It.IsAny<int>());
            Assert.AreEqual(jugadores.Count, otro.Count);

            playerMock.Verify(mock => mock.GetPlayersByTeam(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void GetPlayersFromTeamModelExceptionTest()
        {
            //Create mocks
            var playerMock = new Mock<IPlayerCAD>();
            List<PlayerEN> jugadores = new List<PlayerEN>();
            PlayerEN nuevo = new PlayerEN();
            nuevo.Name = "Pepe";
            jugadores.Add(nuevo);

            playerMock.Setup(mock => mock.GetPlayersByTeam(It.IsAny<int>())).Throws(new ModelException());

            PlayerCEN playerCEN = new PlayerCEN(playerMock.Object);

            try
            {
                IList<PlayerEN> otro = playerCEN.GetPlayersByTeam(It.IsAny<int>());
                Assert.Fail("This method should throw an exception");
            } catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ModelException));
            }

            playerMock.Verify(mock => mock.GetPlayersByTeam(It.IsAny<int>()), Times.Once);
        }

        public void GetPlayersFromTeamDataLayerExceptionTest()
        {
            //Create mocks
            var playerMock = new Mock<IPlayerCAD>();
            List<PlayerEN> jugadores = new List<PlayerEN>();
            PlayerEN nuevo = new PlayerEN();
            nuevo.Name = "Pepe";
            jugadores.Add(nuevo);

            playerMock.Setup(mock => mock.GetPlayersByTeam(It.IsAny<int>())).Throws(new ModelException("Error in playerCAD"));

            PlayerCEN playerCEN = new PlayerCEN(playerMock.Object);

            try
            {
                IList<PlayerEN> otro = playerCEN.GetPlayersByTeam(It.IsAny<int>());
                Assert.Fail("This method should throw an exception");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DataLayerException));
                Assert.AreEqual("Error in PlayerCAD.", e.Message);

            }

            playerMock.Verify(mock => mock.GetPlayersByTeam(It.IsAny<int>()), Times.Once);
        }


    }
}
