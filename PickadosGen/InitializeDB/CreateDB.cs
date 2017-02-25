
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
                SportCEN sportCEN = new SportCEN ();
                int sportId = sportCEN.NewSport ("Football");

                CompetitionCEN competitionCEN = new CompetitionCEN ();
                int competitionId = competitionCEN.NewCompetition ("La Liga", sportId, "Spain");


                TipsterCEN tipsterCEN = new TipsterCEN ();
                int createdTipster = tipsterCEN.NewTipster ("rushverde",
                        "josearuol@gmail.com", "prueba", new DateTime (2017, 2, 25, 11, 0, 0),
                        new DateTime (2017, 2, 25, 11, 0, 0), false, 0);


                //Publishing new post
                PostCEN postCEN = new PostCEN ();
                PostCP postCP = new PostCP ();
                PickCEN pickCEN = new PickCEN ();
                Event_CEN eventCEN = new Event_CEN ();
                int eventId = eventCEN.NewEvent (new DateTime (2017, 10, 25, 11, 0, 0));
                int pickId = pickCEN.NewPick (0, "desc", PickResultEnum.unstarted, "bookie", eventId);
                List<int> picks_id = new List<int>();
                picks_id.Add (pickId);
                postCP.PublishPost (new DateTime (2017, 2, 25, 11, 0, 0), new DateTime (2017, 2, 25, 11, 0, 0), 0, "description", false, picks_id, createdTipster, PickResultEnum.unfinished);

                TeamCEN teamCEN = new TeamCEN ();
                int id_away = teamCEN.NewTeam ("Leganes", "Spain");
                int id_home = teamCEN.NewTeam ("F.C.Barcelona", "Spain");

                MatchCEN matchCEN = new MatchCEN ();
                int id_match = matchCEN.NewMatch (new DateTime (2017, 2, 20), id_away, id_home, "Camp Nou");
                eventCEN.JoinCompetition (id_match, competitionId);

                CorrectScoreCEN correctScoreCEN = new CorrectScoreCEN ();
                int id_correctScore = correctScoreCEN.NewCorrectScore (10, "Scorecast", PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum.won,
                        "Bet365", id_match, 2, 1);
                IList<int> picks = new List<int>();
                picks.Add (id_correctScore);

                int id_post = postCEN.NewPost (new DateTime (2017, 2, 19), new DateTime (2017, 2, 19), 1, "Va a ser un partido sufrido",
                        false, picks, createdTipster, 10, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum.unstarted);

                postCP.VerifyPost (id_post);

                int team1 = teamCEN.NewTeam("SD Eibar", "Spain");
                int team2 = teamCEN.NewTeam("Manchester united", "England");

                int seleccion1 = teamCEN.NewTeam("Selecci�n Espa�ola", "Spain");

                PlayerCEN playerCEN = new PlayerCEN();
                int player1 = playerCEN.NewPlayer("Yoel Rodr�guez");
                int player2 = playerCEN.NewPlayer("Gonzalo Escalante");
                int player3 = playerCEN.NewPlayer("Fran Rico");

                int player4 = playerCEN.NewPlayer("Ander Herrera");
                int player5 = playerCEN.NewPlayer("Juan Mata");

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
