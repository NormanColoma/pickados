
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.CAD.Pickados;

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
                Console.WriteLine("Tipster 4 has: " + totalFollowers8.Count + " followeds");

                Console.WriteLine ("User montoro could login: " + user.Login ("montoro", "montoroPro").Id);
                Console.WriteLine ("User montoro couldn't login: " + user.Login ("montoro", "montoroCola"));

                Console.WriteLine("Converting tipster 1 to premium");
                nuevo.BecomePremium(originalTipster.Id, 2.8);

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
