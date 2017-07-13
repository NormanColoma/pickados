
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

                int tipster = nuevo.NewTipster ("montoro", "montoro@gmail.com", "montoroPro", new DateTime (2017, 5, 2), new DateTime (2017, 5, 2), "25448998G", false, false, 0, false, "Football");
                int tipster1 = nuevo.NewTipster ("jose", "jose@gmail.com", "josePro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 20), "41569269N", false, true, 0, false, "Football");
                int tipster2 = nuevo.NewTipster ("laura", "laura@outlook.com", "lauraPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 25), "15095054Q", false, true, 0, false, "Football");
                int tipster3 = nuevo.NewTipster ("ana", "ana@gmail.com", "anaPro", new DateTime (2017, 1, 1), new DateTime (2017, 2, 20), "41021257K", false, true, 0, false, "Football");
                int tipster4 = nuevo.NewTipster ("maria", "maria@gmail.com", "mariaPro", new DateTime (2017, 5, 2), new DateTime (2017, 5, 2), "24233961B", false, false, 0, false, "Football");
                int tipster5 = nuevo.NewTipster ("aaron", "aaron@gmail.com", "aaronPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 20), "78509149Y", false, false, 0, false, "Football");
                int tipster6 = nuevo.NewTipster ("abdala", "abdala@outlook.com", "abdalaPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 25), "09072257E", false, false, 0, false, "Football");
                int tipster7 = nuevo.NewTipster ("arquimedes", "arquimedes@gmail.com", "arquimedesPro", new DateTime (2017, 1, 1), new DateTime (2017, 2, 20), "88828221J", false, false, 0, false, "Football");

                int tipster8 = nuevo.NewTipster ("casimiro", "casimiro@gmail.com", "casimiroPro", new DateTime (2017, 5, 2), new DateTime (2017, 5, 2), "42940561K", false, false, 0, false, "Football");
                int tipster9 = nuevo.NewTipster ("eulalio", "eulalio@gmail.com", "eulalioPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 20), "90630606A", false, false, 0, false, "Football");
                int tipster10 = nuevo.NewTipster ("edgar", "edgar@outlook.com", "edgarPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 25), "75711312G", false, false, 0, false, "Football");
                int tipster11 = nuevo.NewTipster ("justino", "justino@gmail.com", "justinoPro", new DateTime (2017, 1, 1), new DateTime (2017, 2, 20), "24298795P", false, false, 0, false, "Football");
                int tipster12 = nuevo.NewTipster ("astor", "astor@gmail.com", "astorPro", new DateTime (2017, 5, 2), new DateTime (2017, 5, 2), "08289374J", false, false, 0, false, "Football");
                int tipster13 = nuevo.NewTipster ("cesar", "cesar@gmail.com", "cesarPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 20), "21689311N", false, false, 0, false, "Football");
                int tipster14 = nuevo.NewTipster ("ceferino", "ceferino@outlook.com", "ceferinoPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 25), "41907700K", false, false, 0, false, "Football");
                int tipster15 = nuevo.NewTipster ("clementino", "clementino@gmail.com", "clementinoPro", new DateTime (2017, 1, 1), new DateTime (2017, 2, 20), "49317769L", false, false, 0, false, "Football");

                int tipster16 = nuevo.NewTipster ("rodolfo", "rodolfo@gmail.com", "rodolfoPro", new DateTime (2017, 5, 2), new DateTime (2017, 5, 2), "79577588A", false, false, 0, false, "Football");
                int tipster17 = nuevo.NewTipster ("alvaro", "alvaro@gmail.com", "alvaroPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 20), "21680857E", false, false, 0, false, "Football");
                int tipster18 = nuevo.NewTipster ("auberto", "auberto@outlook.com", "aubertoPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 25), "52574311Z", false, false, 0, false, "Basket");
                int tipster19 = nuevo.NewTipster ("felipe", "felipe@gmail.com", "felipePro", new DateTime (2017, 1, 1), new DateTime (2017, 2, 20), "12543676M", false, false, 0, false, "Basket");
                int tipster20 = nuevo.NewTipster ("cristina", "cristina@gmail.com", "cristinaPro", new DateTime (2017, 5, 2), new DateTime (2017, 5, 2), "91065753J", false, false, 0, false, "Basket");
                int tipster21 = nuevo.NewTipster ("iker", "iker@gmail.com", "ikerPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 20), "41771143S", false, false, 0, false, "Basket");
                int tipster22 = nuevo.NewTipster ("aitor", "aitor@outlook.com", "aitorPro", new DateTime (2017, 2, 20), new DateTime (2017, 2, 25), "46269204N", false, false, 0, false, "Basket");
                int tipster23 = nuevo.NewTipster ("arya", "arya@gmail.com", "aryaPro", new DateTime (2017, 1, 1), new DateTime (2017, 2, 20), "45415817V", false, false, 0, false, "Basket");

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

                DateTime d_march = new DateTime (2017, 3, 8);
                DateTime d_april = new DateTime (2017, 4, 3);
                DateTime d_may = new DateTime (2017, 5, 3);
                DateTime d_june = new DateTime (2017, 6, 3);

                StatsCEN statCEN = new StatsCEN ();
                statCEN.NewMonthlyStats (4, 1, 10, 2, 12, d_march, tipster2, 24, 12);
                statCEN.NewMonthlyStats (3, 3, 25, 3, 3, d_april, tipster2, 9, 9);
                statCEN.NewMonthlyStats (4, 4, 20, 4, 4, d_may, tipster2, 16, 16);
                statCEN.NewMonthlyStats (4, 4, 25, 4, 4, d_june, tipster2, 16, 16);

                statCEN.NewMonthlyStats (4, 1, 30, 2, 12, d_march, tipster, 24, 12);
                statCEN.NewMonthlyStats (3, 3, 0, 3, 3, d_april, tipster, 9, 9);
                statCEN.NewMonthlyStats (4, 4, 5, 4, 4, d_may, tipster, 16, 16);
                statCEN.NewMonthlyStats (1.12, 0.67, 28, 2.29, 6, d_june, tipster, 12, 4);

                statCEN.NewMonthlyStats (4, 1, 11, 2, 12, d_march, tipster3, 24, 12);
                statCEN.NewMonthlyStats (3, 3, 2, 3, 3, d_april, tipster3, 9, 9);
                statCEN.NewMonthlyStats (4, 4, 4, 4, 4, d_may, tipster3, 16, 16);
                statCEN.NewMonthlyStats (57, 1.08, 100, 13.16, 51, d_june, tipster3, 600, 53);

                statCEN.NewMonthlyStats (4, 1, 10, 2, 12, d_march, tipster4, 24, 12);
                statCEN.NewMonthlyStats (3, 3, 25, 3, 3, d_april, tipster4, 9, 9);
                statCEN.NewMonthlyStats (4, 4, 20, 4, 4, d_may, tipster4, 16, 16);
                statCEN.NewMonthlyStats (2.7, 1.44, 23, 1.94, 2, d_june, tipster4, 16, 16);

                statCEN.NewMonthlyStats (4, 1, 10, 2, 12, d_march, tipster5, 24, 12);
                statCEN.NewMonthlyStats (3, 3, 25, 3, 3, d_april, tipster5, 9, 9);
                statCEN.NewMonthlyStats (4, 4, 20, 4, 4, d_may, tipster5, 16, 16);
                statCEN.NewMonthlyStats (4, 4, 22, 4, 4, d_june, tipster5, 16, 16);

                statCEN.NewMonthlyStats (4, 1, 10, 2, 12, d_march, tipster6, 24, 12);
                statCEN.NewMonthlyStats (3, 3, 25, 3, 3, d_april, tipster6, 9, 9);
                statCEN.NewMonthlyStats (4, 4, 20, 4, 4, d_may, tipster6, 16, 16);
                statCEN.NewMonthlyStats (1, 4, 5, 4, 4, d_june, tipster6, 16, 16);

                statCEN.NewMonthlyStats (4, 1, 10, 2, 12, d_march, tipster7, 24, 12);
                statCEN.NewMonthlyStats (3, 3, 25, 3, 3, d_april, tipster7, 9, 9);
                statCEN.NewMonthlyStats (4, 4, 20, 4, 4, d_may, tipster7, 16, 16);
                statCEN.NewMonthlyStats (-1, 4, -1, 4, 4, d_june, tipster7, 16, 16);

                statCEN.NewMonthlyStats (4, 1, 10, 2, 12, d_march, tipster8, 24, 12);
                statCEN.NewMonthlyStats (3, 3, 25, 3, 3, d_april, tipster8, 9, 9);
                statCEN.NewMonthlyStats (4, 4, 20, 4, 4, d_may, tipster8, 16, 16);
                statCEN.NewMonthlyStats (-2, 4, -5, 4, 4, d_june, tipster8, 16, 16);

                statCEN.NewMonthlyStats (4, 1, 10, 2, 12, d_march, tipster9, 24, 12);
                statCEN.NewMonthlyStats (3, 3, 25, 3, 3, d_april, tipster9, 9, 9);
                statCEN.NewMonthlyStats (4, 4, 20, 4, 4, d_may, tipster9, 16, 16);
                statCEN.NewMonthlyStats (-10, 4, -20, 3, 3, d_june, tipster9, 16, 16);


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
                requestCEN.New_ (id_post_1, RequestTypeEnum.modify, "I was wrong", RequestStateEnum.Open, new DateTime (2017, 2, 20));

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
