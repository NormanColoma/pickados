
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.CAD.Pickados;
using PickadosGenNHibernate.CP.Pickados;
using PickadosGenNHibernate.Enumerated.Pickados;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local); database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN [" + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                // Insert the initilizations of entities using the CEN classes
                Console.WriteLine ("------------ Creating new users ------------");
                TipsterCEN nuevo = new TipsterCEN ();
                AdminCEN admin = new AdminCEN ();
                UsuarioCEN user = new UsuarioCEN ();

                int tipster = nuevo.NewTipster ("montoro", "montoro@gmail.com", "montoroPro", new DateTime (2017, 5, 2), new DateTime (2017, 5, 2), "25448998G", false, false, 0, false);
                int tipster1 = nuevo.NewTipster ("jose", "jose@gmail.com", "josePro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 20), "41569269N", false, false, 0, false);
                int tipster2 = nuevo.NewTipster ("laura", "laura@outlook.com", "lauraPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 25), "15095054Q", false, false, 0, false);
                int tipster3 = nuevo.NewTipster ("ana", "ana@gmail.com", "anaPro", new DateTime (2017, 1, 1), new DateTime (2017, 2, 20), "41021257K", false, false, 0, false);
                int tipster4 = nuevo.NewTipster ("maria", "maria@gmail.com", "mariaPro", new DateTime (2017, 5, 2), new DateTime (2017, 5, 2), "24233961B", false, false, 0, false);
                int tipster5 = nuevo.NewTipster ("aaron", "aaron@gmail.com", "aaronPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 20), "78509149Y", false, false, 0, false);
                int tipster6 = nuevo.NewTipster ("abdala", "abdala@outlook.com", "abdalaPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 25), "09072257E", false, false, 0, false);
                int tipster7 = nuevo.NewTipster ("arquimedes", "arquimedes@gmail.com", "arquimedesPro", new DateTime (2017, 1, 1), new DateTime (2017, 2, 20), "88828221J", false, false, 0, false);

                int tipster8 = nuevo.NewTipster ("casimiro", "casimiro@gmail.com", "casimiroPro", new DateTime (2017, 5, 2), new DateTime (2017, 5, 2), "42940561K", false, false, 0, false);
                int tipster9 = nuevo.NewTipster ("eulalio", "eulalio@gmail.com", "eulalioPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 20), "90630606A", false, false, 0, false);
                int tipster10 = nuevo.NewTipster ("edgar", "edgar@outlook.com", "edgarPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 25), "75711312G", false, false, 0, false);
                int tipster11 = nuevo.NewTipster ("justino", "justino@gmail.com", "justinoPro", new DateTime (2017, 1, 1), new DateTime (2017, 2, 20), "24298795P", false, false, 0, false);
                int tipster12 = nuevo.NewTipster ("astor", "astor@gmail.com", "astorPro", new DateTime (2017, 5, 2), new DateTime (2017, 5, 2), "08289374J", false, false, 0, false);
                int tipster13 = nuevo.NewTipster ("cesar", "cesar@gmail.com", "cesarPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 20), "21689311N", false, false, 0, false);
                int tipster14 = nuevo.NewTipster ("ceferino", "ceferino@outlook.com", "ceferinoPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 25), "41907700K", false, false, 0, false);
                int tipster15 = nuevo.NewTipster ("clementino", "clementino@gmail.com", "clementinoPro", new DateTime (2017, 1, 1), new DateTime (2017, 2, 20), "49317769L", false, false, 0, false);

                int tipster16 = nuevo.NewTipster ("rodolfo", "rodolfo@gmail.com", "rodolfoPro", new DateTime (2017, 5, 2), new DateTime (2017, 5, 2), "79577588A", false, false, 0, false);
                int tipster17 = nuevo.NewTipster ("alvaro", "alvaro@gmail.com", "alvaroPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 20), "21680857E", false, false, 0, false);
                int tipster18 = nuevo.NewTipster ("auberto", "auberto@outlook.com", "aubertoPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 25), "52574311Z", false, false, 0, false);
                int tipster19 = nuevo.NewTipster ("felipe", "felipe@gmail.com", "felipePro", new DateTime (2017, 1, 1), new DateTime (2017, 2, 20), "12543676M", false, false, 0, false);
                int tipster20 = nuevo.NewTipster ("cristina", "cristina@gmail.com", "cristinaPro", new DateTime (2017, 5, 2), new DateTime (2017, 5, 2), "91065753J", false, false, 0, false);
                int tipster21 = nuevo.NewTipster ("iker", "iker@gmail.com", "ikerPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 20), "41771143S", false, false, 0, false);
                int tipster22 = nuevo.NewTipster ("aitor", "aitor@outlook.com", "aitorPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 25), "46269204N", false, false, 0, false);
                int tipster23 = nuevo.NewTipster ("arya", "arya@gmail.com", "aryaPro", new DateTime (2017, 1, 1), new DateTime (2017, 2, 20), "45415817V", false, false, 0, false);

                int tipster24 = nuevo.NewTipster("abel", "abel@gmail.com", "abelPro", new DateTime(2017, 6, 2), new DateTime(2017, 6, 2), "61754249P", false, false, 0, false);
                int tipster25 = nuevo.NewTipster("félix", "felix@gmail.com", "felixPro", new DateTime(2017, 6, 20), new DateTime(2017, 6, 20), "58385355Q", false, false, 0, false);
                int tipster26 = nuevo.NewTipster("gerardo", "gerardo@outlook.com", "gerardoPro", new DateTime(2017, 6, 20), new DateTime(2017, 2, 25), "71338334Q", false, false, 0, false);
                int tipster27 = nuevo.NewTipster("gorka", "gorka@gmail.com", "gorkaPro", new DateTime(2017, 1, 1), new DateTime(2017, 6, 20), "33454914B", false, false, 0, false);
                int tipster28 = nuevo.NewTipster("irene", "irene@gmail.com", "irenePro", new DateTime(2017, 5, 2), new DateTime(2017, 5, 2), "10699007M", false, false, 0, false);
                int tipster29 = nuevo.NewTipster("jacob", "jacob@gmail.com", "jacobPro", new DateTime(2017, 6, 20), new DateTime(2017, 6, 20), "81588767Q", false, false, 0, false);
                int tipster30 = nuevo.NewTipster("casinomiro", "casinomiro@outlook.com", "casinomiroPro", new DateTime(2017, 6, 20), new DateTime(2017, 2, 25), "63570598R", false, false, 0, false);
                int tipster31 = nuevo.NewTipster("lidia", "lidia@gmail.com", "lidiaPro", new DateTime(2017, 1, 1), new DateTime(2017, 6, 20), "45567301T", false, false, 0, false);

                int tipster32 = nuevo.NewTipster("ladislao", "ladislao@gmail.com", "ladislaoPro", new DateTime(2017, 5, 2), new DateTime(2017, 5, 2), "43227607G", false, false, 0, false);
                int tipster33 = nuevo.NewTipster("macario", "macario@gmail.com", "macarioPro", new DateTime(2017, 2, 20), new DateTime(2017, 2, 20), "37764644R", false, false, 0, false);
                int tipster34 = nuevo.NewTipster("magdalena", "magdalena@outlook.com", "magdalenaPro", new DateTime(2017, 2, 20), new DateTime(2017, 2, 25), "23934878C", false, false, 0, false);
                int tipster35 = nuevo.NewTipster("mario", "mario@gmail.com", "marioPro", new DateTime(2017, 1, 1), new DateTime(2017, 2, 15), "45032908N", false, false, 0, false);
                int tipster36 = nuevo.NewTipster("miguel", "miguel@gmail.com", "miguelPro", new DateTime(2017, 5, 2), new DateTime(2017, 5, 2), "41662475E", false, false, 0, false);
                int tipster37 = nuevo.NewTipster("mónica", "monica@gmail.com", "monicaPro", new DateTime(2017, 2, 15), new DateTime(2017, 2, 15), "27955763E", false, false, 0, false);
                int tipster38 = nuevo.NewTipster("narciso", "narciso@outlook.com", "narcisoPro", new DateTime(2016, 10, 15), new DateTime(2017, 2, 25), "54890791A", false, false, 0, false);
                int tipster39 = nuevo.NewTipster("norberto", "norberto@gmail.com", "norbertoPro", new DateTime(2017, 1, 1), new DateTime(2016, 10, 15), "64625111X", false, false, 0, false);

                int tipster40 = nuevo.NewTipster("octavio", "octavio@gmail.com", "octavioPro", new DateTime(2017, 5, 2), new DateTime(2017, 5, 2), "40531881Q", false, false, 0, false);
                int tipster41 = nuevo.NewTipster("poncio", "poncio@gmail.com", "poncioPro", new DateTime(2016, 10, 15), new DateTime(2016, 10, 15), "87829369M", false, false, 0, false);
                int tipster42 = nuevo.NewTipster("ramón", "ramon@outlook.com", "ramonPro", new DateTime(2016, 10, 15), new DateTime(2017, 2, 25), "87715833C", false, false, 0, false);
                int tipster43 = nuevo.NewTipster("rafael", "rafael@gmail.com", "rafaelPro", new DateTime(2017, 1, 1), new DateTime(2017, 2, 20), "28091013D", false, false, 0, false);
                int tipster44 = nuevo.NewTipster("rita", "rita@gmail.com", "ritaPro", new DateTime(2017, 5, 2), new DateTime(2017, 5, 2), "18282686D", false, false, 0, false);
                int tipster45 = nuevo.NewTipster("rosalia", "rosalia@gmail.com", "rosaliaPro", new DateTime(2017, 2, 20), new DateTime(2017, 2, 20), "87450233R", false, false, 0, false);
                int tipster46 = nuevo.NewTipster("salvador", "salvador@outlook.com", "salvadorPro", new DateTime(2017, 2, 20), new DateTime(2017, 2, 25), "82432192P", false, false, 0, false);
                int tipster47 = nuevo.NewTipster("susana", "susana@gmail.com", "susanaPro", new DateTime(2017, 1, 1), new DateTime(2017, 2, 20), "82437276D", false, false, 0, false);

                int tipster48 = nuevo.NewTipster("tadeo", "tadeo@gmail.com", "tadeoPro", new DateTime(2017, 5, 2), new DateTime(2017, 5, 2), "68155029A", false, false, 0, false);
                int tipster49 = nuevo.NewTipster("teodora", "teodora@gmail.com", "teodoraPro", new DateTime(2017, 2, 20), new DateTime(2017, 2, 20), "79951906L", false, false, 0, false);
                int tipster50 = nuevo.NewTipster("timoteo", "timoteo@outlook.com", "timoteoPro", new DateTime(2017, 2, 20), new DateTime(2017, 2, 25), "29911267C", false, false, 0, false);
                int tipster51 = nuevo.NewTipster("toribio", "toribio@gmail.com", "toribioPro", new DateTime(2017, 1, 1), new DateTime(2017, 2, 20), "05576746M", false, false, 0, false);
                int tipster52 = nuevo.NewTipster("ubaldo", "ubaldo@gmail.com", "ubaldoPro", new DateTime(2017, 5, 2), new DateTime(2017, 5, 2), "33993384M", false, false, 0, false);
                int tipster53 = nuevo.NewTipster("ursula", "ursula@gmail.com", "ursulaPro", new DateTime(2017, 2, 20), new DateTime(2017, 2, 20), "13895015W", false, false, 0, false);
                int tipster54 = nuevo.NewTipster("valentina", "valentina@outlook.com", "valentinaPro", new DateTime(2017, 2, 20), new DateTime(2017, 2, 25), "32731592Q", false, false, 0, false);
                int tipster55 = nuevo.NewTipster("zacarias", "zacarias@gmail.com", "zacariasPro", new DateTime(2017, 1, 1), new DateTime(2017, 2, 20), "65786469Y", false, false, 0, false);

                admin.NewAdmin ("admin", "admin@outlook.com", "adminPro", new DateTime (2017, 3, 14), new DateTime (2017, 8, 6), "65478912N", true);

                TipsterEN originalTipster = nuevo.GetTipsterById (tipster);
                TipsterEN newTipster = nuevo.GetTipsterById (tipster1);
                TipsterEN otherTipster = nuevo.GetTipsterById (tipster2);
                TipsterEN lastTipster = nuevo.GetTipsterById (tipster3);

                // Seguidores
                IList<int> followers = new List<int>();
                IList<int> unfollows = new List<int>();

                // Creamos seguidores
                followers.Add (newTipster.Id);
                followers.Add (otherTipster.Id);

                // A�adidos dos seguidores para el tipster 1
                Console.WriteLine ("Adding two new followers for tipster 1");
                //nuevo.AddFollower (originalTipster.Id, followers);
                nuevo.AddingFollower (originalTipster.Id, newTipster.Id);
                nuevo.AddingFollower (originalTipster.Id, otherTipster.Id);

                IList<TipsterEN> totalFollowers = nuevo.GetFollowers (originalTipster.Id);
                Console.WriteLine ("Tipster 1 has: " + totalFollowers.Count + " followers");

                IList<TipsterEN> totalFollows1 = nuevo.GetFollows (originalTipster.Id);
                Console.WriteLine ("Tipster 1 has: " + totalFollows1.Count + " followeds");

                IList<TipsterEN> totalFollows2 = nuevo.GetFollows (newTipster.Id);
                Console.WriteLine ("Tipster 2 has: " + totalFollows2.Count + " followers");

                // A�adir otro seguidor al tipster 1
                Console.WriteLine ("Added one more follower for tipster 1");
                followers.Clear ();
                followers.Add (lastTipster.Id);

                //nuevo.AddFollower (originalTipster.Id, followers);
                nuevo.AddingFollower (originalTipster.Id, lastTipster.Id);

                IList<TipsterEN> totalFollowers4 = nuevo.GetFollowers (originalTipster.Id);
                Console.WriteLine ("Tipster 1 has: " + totalFollowers4.Count + " followers");

                IList<TipsterEN> totalFollows6 = nuevo.GetFollows (originalTipster.Id);
                Console.WriteLine ("Tipster 1 has: " + totalFollows6.Count + " followeds");

                IList<TipsterEN> totalFollows5 = nuevo.GetFollows (lastTipster.Id);
                Console.WriteLine ("Tipster 4 has: " + totalFollows5.Count + " followeds");

                // Eliminar seguidores al tipster 1
                Console.WriteLine ("Added one unfollow for tipster 1");
                unfollows.Add (lastTipster.Id);
                //nuevo.DeleteFollow (originalTipster.Id, unfollows);
                nuevo.DeletingFollower (originalTipster.Id, lastTipster.Id);

                IList<TipsterEN> totalFollowers7 = nuevo.GetFollowers (originalTipster.Id);
                Console.WriteLine ("Tipster 1 has: " + totalFollowers7.Count + " followers");

                IList<TipsterEN> totalFollowers8 = nuevo.GetFollows (lastTipster.Id);
                Console.WriteLine ("Tipster 4 has: " + totalFollowers8.Count + " followeds");

                Console.WriteLine ("User montoro could login: " + user.Login ("montoro", "montoroPro").Id);
                Console.WriteLine ("User montoro couldn't login: " + user.Login ("montoro", "montoroCola"));

                Console.WriteLine ("Converting tipster 1 to premium");
                nuevo.BecomePremium (originalTipster.Id, 2.8);

                //Console.WriteLine ("There are " + nuevo.GetTipstersPremium ().Count + " premium tipsters");

                Console.WriteLine ("--------------- Creating new Sport -------------");
                SportCEN sport = new SportCEN ();
                int newSport = sport.NewSport ("Football", "https://cdn0.iconfinder.com/data/icons/stroke-ball-icons-2/633/02_Soccer-512.png");
                Console.WriteLine ("Football created");
                int newSport2 = sport.NewSport ("Basketball", "https://images.vexels.com/media/users/3/129332/isolated/lists/b3f0ad2e079ac9027c5eb0a2d1c8549b-basketball-silhouette-icon.png");
                Console.WriteLine ("Basketball created");

                Console.WriteLine ("--------------- Creating new Season -------------");
                SeasonCEN seasons = new SeasonCEN ();
                int season1 = seasons.NewSeason (new DateTime (2016, 8, 18), new DateTime (2017, 5, 19));
                Console.WriteLine ("Season 16/17 Santander created");
                int season2 = seasons.NewSeason (new DateTime (2016, 8, 18), new DateTime (2017, 5, 19));
                Console.WriteLine ("Season 16/17 ACB created");

                Console.WriteLine ("--------------- Creating new Round -------------");
                RoundCEN rounds = new RoundCEN ();
                int round1 = rounds.NewRound (season1, "Jornada 1");
                Console.WriteLine ("Round 1 Santander created");
                int round2 = rounds.NewRound (season1, "Jornada 2");
                Console.WriteLine ("Round 2 Santander created");

                // Añadimos datos a Equipos
                Console.WriteLine ("------------- Creating new teams -------------");
                TeamCEN teamCEN = new TeamCEN ();
                int team1 = teamCEN.NewTeam ("Barcelona", "Catalunya", true);
                TeamEN equipo1 = teamCEN.GetTeamById (team1);
                Console.WriteLine ("New team: " + equipo1.Name);

                int team2 = teamCEN.NewTeam ("Madrid", "Spain", true);
                TeamEN equipo2 = teamCEN.GetTeamById (team2);
                Console.WriteLine ("New team: " + equipo2.Name);

                int team3 = teamCEN.NewTeam ("Juventus", "Italy", true);
                TeamEN equipo3 = teamCEN.GetTeamById (team3);
                Console.WriteLine ("New team: " + equipo3.Name);

                int team4 = teamCEN.NewTeam ("SD Eibar", "Spain", true);
                TeamEN equipo4 = teamCEN.GetTeamById (team4);
                Console.WriteLine ("New team: " + equipo4.Name);

                int team5 = teamCEN.NewTeam ("Manchester united", "England", true);
                TeamEN equipo5 = teamCEN.GetTeamById (team5);
                Console.WriteLine ("New team: " + equipo5.Name);

                int team6 = teamCEN.NewTeam ("Barça Basket", "Spain", true);
                TeamEN equipo6 = teamCEN.GetTeamById (team6);
                Console.WriteLine ("New team: " + equipo6.Name);

                int team7 = teamCEN.NewTeam ("Gran Canaria Basket", "Spain", true);
                TeamEN equipo7 = teamCEN.GetTeamById (team7);
                Console.WriteLine ("New team: " + equipo7.Name);

                int selection1 = teamCEN.NewTeam ("Selección Española", "Spain", false);
                TeamEN seleccion1 = teamCEN.GetTeamById (selection1);
                Console.WriteLine ("New team: " + seleccion1.Name);

                // Añadimos datos a Partidos
                Console.WriteLine ("------------- Creating new Matches -------------");
                MatchCEN match = new MatchCEN ();
                int match1 = match.NewMatch (new DateTime (2017, 4, 2), round1, team2, team1, "Camp Nou");
                MatchEN partido1 = match.GetMatchById (match1);
                Console.WriteLine ("New match in: " + partido1.Stadium);
                int match2 = match.NewMatch (new DateTime (2017, 3, 17), round1, team1, team3, "Juventus Stadium");
                MatchEN partido2 = match.GetMatchById (match2);
                Console.WriteLine ("New match in: " + partido2.Stadium);
                int match3 = match.NewMatch (new DateTime (2017, 3, 30), round1, team6, team7, "Palau");
                MatchEN partido3 = match.GetMatchById (match3);
                Console.WriteLine ("New match in: " + partido3.Stadium);

                Console.WriteLine ("Local and Visistant matches");
                IList<MatchEN> totalMatch = match.GetMatchByLocalTeam (team1);
                Console.WriteLine ("Barcelona has played: " + totalMatch.Count + " matches as local");
                IList<MatchEN> totalMatch1 = match.GetMatchByVisistantTeam (team1);
                Console.WriteLine ("Barcelona has played: " + totalMatch1.Count + " matches as visitant");
                IList<MatchEN> totalMatch2 = match.GetMatchByVisistantTeam (team2);
                Console.WriteLine ("Madrid has played: " + totalMatch2.Count + " matches as visistant");

                IList<MatchEN> total = match.GetTotalMatchesByTeam (team1);
                Console.WriteLine ("Barcelona has played: " + total.Count + " matches");

                Console.WriteLine ("--------------- Creating new Competition -------------");
                List<int> seasonsSantander = new List<int>();
                seasonsSantander.Add (season1);
                List<int> seasonsACB = new List<int>();
                seasonsACB.Add (season2);
                CompetitionCEN competi = new CompetitionCEN ();
                int competition = competi.NewCompetition ("Santander League", newSport, "Spain", true, seasonsSantander);
                Console.WriteLine ("Santander League created");
                Console.WriteLine ("There are " + competi.GetCompetitionsByPlace ("Spain").Count + " competitions in Spain");
                int competition2 = competi.NewCompetition ("ACB", newSport2, "Spain", true, seasonsACB);

                Console.WriteLine ("Joining Barcelona-Madrid to Santander League");
                Event_CEN evento = new Event_CEN ();
                evento.JoinCompetition (match1, competition);
                Console.WriteLine ("There are " + match.GetMatchByCompetition (competition, 0, 0).Count + " matches in Santander League");

                evento.JoinCompetition (match3, competition2);
                Console.WriteLine ("There are " + match.GetMatchByCompetition (competition2, 0, 0).Count + " matches in ACB");

                Console.WriteLine ("Joining teams to Competitions");
                IList<int> competSpain = new List<int>();
                competSpain.Add (competition);
                IList<int> competSpainBasket = new List<int>();
                competSpainBasket.Add (competition2);
                teamCEN.AddCompetition (team1, competSpain);
                teamCEN.AddCompetition (team2, competSpain);
                teamCEN.AddCompetition (team4, competSpain);
                teamCEN.AddCompetition (team6, competSpainBasket);
                Console.WriteLine ("There are " + teamCEN.GetTeamByCompetition (competition).Count + " teams in Santander League");
                Console.WriteLine ("There are " + competi.GetAllCompetitions (0, 2000).Count + " competitions");

                Console.WriteLine ("--------------- Creating new Players -------------");
                PlayerCEN playerCEN = new PlayerCEN ();
                int player1 = playerCEN.NewPlayer ("Yoel Rodríguez", newSport);
                PlayerEN jugador1 = playerCEN.GetPlayerById (player1);
                Console.WriteLine ("New player: " + jugador1.Name);

                int player2 = playerCEN.NewPlayer ("Gonzalo Escalante", newSport);
                PlayerEN jugador2 = playerCEN.GetPlayerById (player2);
                Console.WriteLine ("New player: " + jugador2.Name);

                int player3 = playerCEN.NewPlayer ("Fran Rico", newSport);
                PlayerEN jugador3 = playerCEN.GetPlayerById (player3);
                Console.WriteLine ("New player: " + jugador3.Name);

                int player4 = playerCEN.NewPlayer ("Ander Herrera", newSport);
                PlayerEN jugador4 = playerCEN.GetPlayerById (player4);
                Console.WriteLine ("New player: " + jugador4.Name);

                int player5 = playerCEN.NewPlayer ("Juan Mata", newSport);
                PlayerEN jugador5 = playerCEN.GetPlayerById (player5);
                Console.WriteLine ("New player: " + jugador5.Name);

                int player6 = playerCEN.NewPlayer ("Juan Carlos Navarro", newSport2);
                PlayerEN jugador6 = playerCEN.GetPlayerById (player6);
                Console.WriteLine ("New player: " + jugador6.Name);

                Console.WriteLine ("--------------- Join Player with Teams -------------");
                PlayerCAD playerCAD = new PlayerCAD ();
                playerCAD.JoinClubTeam (player1, team4);
                Console.WriteLine ("The player " + jugador1.Name + " plays in " + equipo4.Name);

                playerCAD.JoinClubTeam (player2, team4);
                Console.WriteLine ("The player " + jugador2.Name + " plays in " + equipo4.Name);

                playerCAD.JoinClubTeam (player3, team4);
                Console.WriteLine ("The player " + jugador3.Name + " plays in " + equipo4.Name);

                playerCAD.JoinClubTeam (player4, team5);
                Console.WriteLine ("The player " + jugador4.Name + " plays in " + equipo5.Name);

                playerCAD.JoinClubTeam (player5, team5);
                Console.WriteLine ("The player " + jugador5.Name + " plays in " + equipo5.Name);

                playerCAD.JoinNationalTeam (player4, selection1);
                Console.WriteLine ("The player " + jugador2.Name + " plays in " + seleccion1.Name);

                playerCAD.JoinNationalTeam (player5, selection1);
                Console.WriteLine ("The player " + jugador5.Name + " plays in " + seleccion1.Name);

                Console.WriteLine ("--------------- Unlink Player with Teams -------------");
                playerCAD.UnlinkClubTeam (player5, team5);
                Console.WriteLine ("The player " + jugador5.Name + " doesn't play in " + equipo5.Name);

                Console.WriteLine ("--------------- Get Player by club team -------------");
                IList<PlayerEN> players1 = playerCAD.GetPlayersByClubTeam (equipo4.Name, 0, 0);
                Console.WriteLine ("Players in " + equipo4.Name + ":");
                foreach (var p in players1)
                        Console.WriteLine ("- " + p.Name);

                Console.WriteLine ("--------------- Get Player by national team -------------");
                IList<PlayerEN> players2 = playerCAD.GetPlayersByNationalTeam (seleccion1.Name);
                Console.WriteLine ("Players in " + seleccion1.Name + ":");
                foreach (var p in players2)
                        Console.WriteLine ("- " + p.Name);

                //Publishing new post
                PostCEN postCEN = new PostCEN ();
                PostCP postCP = new PostCP ();
                ResultCEN resultCEN = new ResultCEN ();
                Event_CEN eventCEN = new Event_CEN ();
                //int eventId = eventCEN.NewEvent (new DateTime (2017, 10, 25, 11, 0, 0), round1);
                int pickId = resultCEN.NewResult (2, "Gana Local", PickResultEnum.unstarted, "Kirolbet", match1, ResultEnum.home, TimeEnum.fulltime);
                List<int> picks_id = new List<int>();
                picks_id.Add (pickId);
                postCP.PublishPost (new DateTime (2017, 2, 25, 11, 0, 0), new DateTime (2017, 2, 25, 11, 0, 0), 0, "description", false, picks_id, tipster2, PickResultEnum.unfinished);

                Console.WriteLine ("--------------- Get Post by Tipster -------------");
                PostCAD postCAD = new PostCAD ();
                IList<PostEN> posts = postCAD.FindPostsByTipster (tipster2, 0, 10);
                foreach (var p in posts) {
                        Console.WriteLine ("- " + p.Description);
                }

                MatchCEN matchCEN = new MatchCEN ();
                int id_match = matchCEN.NewMatch (new DateTime (2017, 2, 20), round1, team1, team5, "Camp Nou");
                eventCEN.JoinCompetition (id_match, competition);

                CorrectScoreCEN correctScoreCEN = new CorrectScoreCEN ();
                int id_correctScore = correctScoreCEN.NewCorrectScore (10, "Scorecast", PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum.won,
                        "Bet365", id_match, 2, 1);
                IList<int> picks = new List<int>();
                picks.Add (id_correctScore);

                int id_post_1 = postCEN.NewPost (new DateTime (2017, 2, 18), new DateTime (2017, 2, 18), 1, "Va a ser un partido sufrido",
                        false, picks, tipster1, 10, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum.unstarted, 0, 5);

                int id_post_2 = postCEN.NewPost (new DateTime (2017, 2, 18), new DateTime (2017, 2, 18), 1, "Va a ser un partido sufrido 2",
                        false, picks, tipster1, 10, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum.unstarted, 16, 0);

                int id_post_3 = postCEN.NewPost (new DateTime (2017, 2, 25), new DateTime (2017, 2, 25), 1, "Va a ser un partido sufrido 3",
                        false, picks, tipster1, 10, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum.unstarted, 70, 0);

                int id_post_4 = postCEN.NewPost (new DateTime (2017, 2, 28), new DateTime (2017, 2, 28), 1, "Va a ser un partido sufrido 4",
                        false, picks, tipster1, 10, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum.unstarted, 5, 0);

                int id_post_5 = postCEN.NewPost (new DateTime (2017, 9, 30), new DateTime (2017, 9, 30), 1, "Va a ser un partido sufrido 5",
                        false, picks, tipster1, 10, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum.unstarted, 2000, 0);

                int id_post_6 = postCEN.NewPost (new DateTime (2017, 9, 30), new DateTime (2017, 9, 30), 1, "Va a ser un partido sufrido 6",
                        false, picks, tipster2, 10, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum.unstarted, 20, 0);

                int id_post_7 = postCEN.NewPost (new DateTime (2017, 9, 30), new DateTime (2017, 9, 30), 1, "Va a ser un partido sufrido 7",
                        false, picks, tipster2, 10, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum.unstarted, 700, 0);

                int id_post_8 = postCEN.NewPost (new DateTime (2017, 9, 30), new DateTime (2017, 9, 30), 1, "Va a ser un partido sufrido 8",
                        false, picks, tipster3, 10, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum.unstarted, 700, 0);

                postCP.VerifyPost (id_post_1);
                postCEN.AddLike (id_post_1);

                postCP.VerifyPost (id_post_2);
                postCEN.AddLike (id_post_2);

                postCP.VerifyPost (id_post_3);
                postCEN.AddLike (id_post_3);

                postCP.VerifyPost (id_post_4);
                postCEN.AddLike (id_post_4);

                postCP.VerifyPost (id_post_5);
                postCEN.AddLike (id_post_5);

                postCP.VerifyPost (id_post_6);
                postCEN.AddLike (id_post_6);

                postCP.VerifyPost (id_post_7);
                postCEN.AddLike (id_post_7);

                postCP.VerifyPost (id_post_8);
                postCEN.AddLike (id_post_8);

                DateTime d = new DateTime (2017, 3, 8);

                StatsCEN statCEN = new StatsCEN ();
                statCEN.NewMonthlyStats (1, 1, 1, 1, 1, d, tipster2, 1, 1);
                statCEN.NewMonthlyStats (2, 2, 2, 2, 2, d.AddDays (2), tipster2, 2, 2);
                statCEN.NewMonthlyStats (3, 3, 3, 3, 3, d.AddMonths (2), tipster2, 3, 3);
                statCEN.NewMonthlyStats (4, 4, 4, 4, 4, d.AddMonths (4), tipster2, 4, 4);

                Console.WriteLine ("--------------- Get Stats by Tipster -------------");
                StatsCAD statCAD = new StatsCAD ();
                IList<StatsEN> stats = statCAD.GetStatsByTipster (otherTipster.Alias);
                foreach (var s in stats)
                        Console.WriteLine ("- " + s.Benefit);

                Console.WriteLine ("--------- Get March's 2017 Stats by Tipster -------");
                IList<StatsEN> statsMarch = statCAD.GetStatsByMonthTipster (otherTipster.Alias, MonthsEnum.March, 2017);
                foreach (var s in statsMarch)
                        Console.WriteLine ("- " + s.Date);

                Console.WriteLine ("--------- Get May's 2018 tats by Tipster (empty) -------");
                IList<StatsEN> statsMay = statCAD.GetStatsByMonthTipster (otherTipster.Alias, MonthsEnum.May, 2018);
                foreach (var s in statsMay)
                        Console.WriteLine ("- " + s.Date);
                // Creating requests

                RequestCEN requestCEN = new RequestCEN ();
                requestCEN.New_ (id_post_1, RequestTypeEnum.modify, "I was wrong", RequestStateEnum.Open, new DateTime (2017, 2, 20), "", new DateTime (1900, 01, 01));

                LoginCEN loginCEN = new LoginCEN ();
                loginCEN.NewLogin ("arya", new DateTime (2016, 06, 01));
                loginCEN.NewLogin ("edgar", new DateTime (2016, 06, 11));
                loginCEN.NewLogin ("justino", new DateTime (2016, 06, 15));
                loginCEN.NewLogin ("clementino", new DateTime (2016, 07, 01));
                loginCEN.NewLogin ("rodolfo", new DateTime (2016, 07, 01));
                loginCEN.NewLogin ("rodolfo", new DateTime (2016, 10, 15));
                loginCEN.NewLogin ("rodolfo", new DateTime (2018, 01, 01));
                loginCEN.NewLogin ("rodolfo", new DateTime (2015, 01, 01));
                loginCEN.NewLogin ("auberto", new DateTime (2017, 06, 01));
                loginCEN.NewLogin ("arya", new DateTime (2017, 06, 01));

                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
