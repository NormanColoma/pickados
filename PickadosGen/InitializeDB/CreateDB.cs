
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
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
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

                int tipster = nuevo.NewTipster ("montoro", "montoro@gmail.com", "montoroPro", new DateTime (2017, 5, 2), new DateTime (2017, 5, 2), "12345678B", false, 0);
                int tipster1 = nuevo.NewTipster ("jose", "jose@gmail.com", "josePro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 20), "25836914C", false, 0);
                int tipster2 = nuevo.NewTipster ("laura", "laura@outlook.com", "lauraPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 25), "36924518Z", false, 0);
                int tipster3 = nuevo.NewTipster ("ana", "ana@gmail.com", "anaPro", new DateTime (2017, 1, 1), new DateTime (2017, 2, 20), "56478912P", false, 0);

                admin.NewAdmin ("admin", "admin@outlook.com", "adminPro", new DateTime (2017, 3, 14), new DateTime (2017, 8, 6), "65478912N");

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
                nuevo.AddFollower (originalTipster.Id, followers);

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

                nuevo.AddFollower (originalTipster.Id, followers);

                IList<TipsterEN> totalFollowers4 = nuevo.GetFollowers (originalTipster.Id);
                Console.WriteLine ("Tipster 1 has: " + totalFollowers4.Count + " followers");

                IList<TipsterEN> totalFollows6 = nuevo.GetFollows (originalTipster.Id);
                Console.WriteLine ("Tipster 1 has: " + totalFollows6.Count + " followeds");

                IList<TipsterEN> totalFollows5 = nuevo.GetFollows (lastTipster.Id);
                Console.WriteLine ("Tipster 4 has: " + totalFollows5.Count + " followeds");

                // Eliminar seguidores al tipster 1
                Console.WriteLine ("Added one unfollow for tipster 1");
                unfollows.Add (lastTipster.Id);
                nuevo.DeleteFollow (originalTipster.Id, unfollows);

                IList<TipsterEN> totalFollowers7 = nuevo.GetFollowers (originalTipster.Id);
                Console.WriteLine ("Tipster 1 has: " + totalFollowers7.Count + " followers");

                IList<TipsterEN> totalFollowers8 = nuevo.GetFollows (lastTipster.Id);
                Console.WriteLine ("Tipster 4 has: " + totalFollowers8.Count + " followeds");

                Console.WriteLine ("User montoro could login: " + nuevo.Login ("montoro", "montoroPro").Id);
                Console.WriteLine ("User montoro couldn't login: " + nuevo.Login ("montoro", "montoroCola"));

                Console.WriteLine ("Converting tipster 1 to premium");
                nuevo.BecomePremium (originalTipster.Id, 2.8);

                Console.WriteLine ("There are " + nuevo.GetTipstersPremium ().Count + " premium tipsters");

                // Añadimos datos a Equipos
                Console.WriteLine ("------------- Creating new teams -------------");
                TeamCEN teamCEN = new TeamCEN ();
                int team1 = teamCEN.NewTeam ("Barcelona", "Catalunya");
                TeamEN equipo1 = teamCEN.GetTeamById (team1);
                Console.WriteLine ("New team: " + equipo1.Name);

                int team2 = teamCEN.NewTeam ("Madrid", "Spain");
                TeamEN equipo2 = teamCEN.GetTeamById (team2);
                Console.WriteLine ("New team: " + equipo2.Name);

                int team3 = teamCEN.NewTeam ("Juventus", "Italy");
                TeamEN equipo3 = teamCEN.GetTeamById (team3);
                Console.WriteLine ("New team: " + equipo3.Name);

                int team4 = teamCEN.NewTeam ("SD Eibar", "Spain");
                TeamEN equipo4 = teamCEN.GetTeamById (team4);
                Console.WriteLine ("New team: " + equipo4.Name);

                int team5 = teamCEN.NewTeam ("Manchester united", "England");
                TeamEN equipo5 = teamCEN.GetTeamById (team5);
                Console.WriteLine ("New team: " + equipo5.Name);

                int team6 = teamCEN.NewTeam ("Barça Basket", "Spain");
                TeamEN equipo6 = teamCEN.GetTeamById (team6);
                Console.WriteLine ("New team: " + equipo6.Name);

                int team7 = teamCEN.NewTeam ("Gran Canaria Basket", "Spain");
                TeamEN equipo7 = teamCEN.GetTeamById (team7);
                Console.WriteLine ("New team: " + equipo7.Name);

                int selection1 = teamCEN.NewTeam ("Selección Española", "Spain");
                TeamEN seleccion1 = teamCEN.GetTeamById (selection1);
                Console.WriteLine ("New team: " + seleccion1.Name);

                // Añadimos datos a Partidos
                Console.WriteLine ("------------- Creating new Matches -------------");
                MatchCEN match = new MatchCEN ();
                int match1 = match.NewMatch (new DateTime (2017, 4, 2), team2, team1, "Camp Nou");
                MatchEN partido1 = match.GetMatchById (match1);
                Console.WriteLine ("New match in: " + partido1.Stadium);
                int match2 = match.NewMatch (new DateTime (2017, 3, 17), team1, team3, "Juventus Stadium");
                MatchEN partido2 = match.GetMatchById (match2);
                Console.WriteLine ("New match in: " + partido2.Stadium);
                int match3 = match.NewMatch (new DateTime (2017, 3, 30), team6, team7, "Palau");
                MatchEN partido3 = match.GetMatchById (match3);
                Console.WriteLine ("New match in: " + partido2.Stadium);

                Console.WriteLine ("Local and Visistant matches");
                IList<MatchEN> totalMatch = match.GetMatchByLocalTeam (team1);
                Console.WriteLine ("Barcelona has played: " + totalMatch.Count + " matches as local");
                IList<MatchEN> totalMatch1 = match.GetMatchByVisistantTeam (team1);
                Console.WriteLine ("Barcelona has played: " + totalMatch1.Count + " matches as visitant");
                IList<MatchEN> totalMatch2 = match.GetMatchByVisistantTeam (team2);
                Console.WriteLine ("Madrid has played: " + totalMatch2.Count + " matches as visistant");

                IList<MatchEN> total = match.GetTotalMatchesByTeam (team1);
                Console.WriteLine ("Barcelona has played: " + total.Count + " matches");

                Console.WriteLine ("--------------- Creating new Sport -------------");
                SportCEN sport = new SportCEN ();
                int newSport = sport.NewSport ("Football");
                Console.WriteLine ("Football created");
                int newSport2 = sport.NewSport ("Basketball");
                Console.WriteLine ("Basketball created");

                Console.WriteLine ("--------------- Creating new Competition -------------");
                CompetitionCEN competi = new CompetitionCEN ();
                int competition = competi.NewCompetition ("Santander League", newSport, "Spain");
                Console.WriteLine ("Santander League created");
                Console.WriteLine ("There are " + competi.GetCompetitionsByPlace ("Spain").Count + " competitions in Spain");
                int competition2 = competi.NewCompetition ("ACB", newSport2, "Spain");

                Console.WriteLine ("Joining Barcelona-Madrid to Santander League");
                Event_CEN evento = new Event_CEN ();
                evento.JoinCompetition (match1, competition);
                Console.WriteLine ("There are " + match.GetMatchByCompetition (competition).Count + " matches in Santander League");

                evento.JoinCompetition (match3, competition2);
                Console.WriteLine ("There are " + match.GetMatchByCompetition (competition2).Count + " matches in ACB");

                Console.WriteLine ("--------------- Creating new Players -------------");
                PlayerCEN playerCEN = new PlayerCEN ();
                int player1 = playerCEN.NewPlayer ("Yoel Rodríguez");
                PlayerEN jugador1 = playerCEN.GetPlayerById (player1);
                Console.WriteLine ("New player: " + jugador1.Name);

                int player2 = playerCEN.NewPlayer ("Gonzalo Escalante");
                PlayerEN jugador2 = playerCEN.GetPlayerById (player2);
                Console.WriteLine ("New player: " + jugador2.Name);

                int player3 = playerCEN.NewPlayer ("Fran Rico");
                PlayerEN jugador3 = playerCEN.GetPlayerById (player3);
                Console.WriteLine ("New player: " + jugador3.Name);

                int player4 = playerCEN.NewPlayer ("Ander Herrera");
                PlayerEN jugador4 = playerCEN.GetPlayerById (player4);
                Console.WriteLine ("New player: " + jugador4.Name);

                int player5 = playerCEN.NewPlayer ("Juan Mata");
                PlayerEN jugador5 = playerCEN.GetPlayerById (player5);
                Console.WriteLine ("New player: " + jugador5.Name);

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
                IList<PlayerEN> players1 = playerCAD.GetPlayersByClubTeam (equipo4.Name);
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
                ResultCEN resultCEN = new ResultCEN();
                Event_CEN eventCEN = new Event_CEN ();
                int eventId = eventCEN.NewEvent (new DateTime (2017, 10, 25, 11, 0, 0));
                int pickId = resultCEN.NewResult (2,"Gana Local",PickResultEnum.unstarted,"Kirolbet",match1,ResultEnum.home,TimeEnum.fulltime);
                List < int > picks_id = new List<int>();
                picks_id.Add (pickId);
                postCP.PublishPost (new DateTime (2017, 2, 25, 11, 0, 0), new DateTime (2017, 2, 25, 11, 0, 0), 0, "description", false, picks_id, tipster2, PickResultEnum.unfinished);


                MatchCEN matchCEN = new MatchCEN ();
                int id_match = matchCEN.NewMatch (new DateTime (2017, 2, 20), team1, team5, "Camp Nou");
                eventCEN.JoinCompetition (id_match, competition);

                CorrectScoreCEN correctScoreCEN = new CorrectScoreCEN ();
                int id_correctScore = correctScoreCEN.NewCorrectScore (10, "Scorecast", PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum.won,
                        "Bet365", id_match, 2, 1);
                IList < int > picks = new List<int>();
                picks.Add (id_correctScore);

                int id_post = postCEN.NewPost (new DateTime (2017, 2, 19), new DateTime (2017, 2, 19), 1, "Va a ser un partido sufrido",
                        false, picks, tipster1, 10, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum.unstarted);

                postCP.VerifyPost (id_post);

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
