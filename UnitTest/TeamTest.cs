using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickadosGenNHibernate.CEN.Pickados;
using Moq;
using PickadosGenNHibernate.CAD.Pickados;
using PickadosGenNHibernate.EN.Pickados;

namespace UnitTest
{
    /// <summary>
    /// Descripción resumida de TeamTest
    /// </summary>
    [TestClass]
    public class TeamTest
    {
        public TeamTest()
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

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CreateTeamOkTest()
        {
            string expected = "Eibar";
            //Create mocks
            var teamMock = new Mock<ITeamCAD>();

            //Setup mock methods
            TeamEN teamEN = new TeamEN();
            teamEN.Name = "Eibar";

            teamMock.Setup(mock => mock.NewTeam(It.IsAny<TeamEN>())).Returns(1);
            teamMock.Setup(mock => mock.GetByID(It.IsAny<int>())).Returns(teamEN);

            TeamCEN teamCEN = new TeamCEN(teamMock.Object);
            TeamEN actualTeam = teamCEN.GetByID(It.IsAny<int>());

            //Test method (check if picks are equal)
            Assert.AreEqual(actualTeam.Name, expected);

            //Verify mocks
            teamMock.Verify(mock => mock.GetByID(It.IsAny<int>()), Times.Once);
        }

        /*
        [TestMethod]
        public void JoinClubTeamOkTest()
        {
            //Create mocks
            var playerMock = new Mock<IPlayerCAD>();

            //Setup mock methods
            playerMock.Setup(mock => mock.NewPlayer(It.IsAny<PlayerEN>())).Returns(1);
            PlayerCEN playerCEN = new PlayerCEN(playerMock.Object);

            playerCEN.JoinClubTeam(It.IsAny<int>(), It.IsAny<int>());

            //Test method (check if picks are equal)
            Assert.AreEqual(, "");

            //Verify mocks
            playerMock.Verify(mock => mock.NewPlayer(It.IsAny<PlayerEN>()), Times.Once);
        }
        */

        [TestMethod]
        public void JoinClubTeamOkTest()
        {
            //Create mocks
            var playerMock = new Mock<IPlayerCAD>();
            PlayerCEN playerCEN = new PlayerCEN(playerMock.Object);

            try {
                playerCEN.JoinClubTeam(It.IsAny<int>(), It.IsAny<int>());
            }
            catch(Exception ex) {
                Assert.Fail();
            }
        }
    }
}
