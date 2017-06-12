
using System;
using System.Text;
using PickadosGenNHibernate.CEN.Pickados;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.Exceptions;


/*
 * Clase Player:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial class PlayerCAD : BasicCAD, IPlayerCAD
{
public PlayerCAD() : base ()
{
}

public PlayerCAD(ISession sessionAux) : base (sessionAux)
{
}



public PlayerEN ReadOIDDefault (int id
                                )
{
        PlayerEN playerEN = null;

        try
        {
                SessionInitializeTransaction ();
                playerEN = (PlayerEN)session.Get (typeof(PlayerEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PlayerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return playerEN;
}

public System.Collections.Generic.IList<PlayerEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PlayerEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PlayerEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PlayerEN>();
                        else
                                result = session.CreateCriteria (typeof(PlayerEN)).List<PlayerEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PlayerCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PlayerEN player)
{
        try
        {
                SessionInitializeTransaction ();
                PlayerEN playerEN = (PlayerEN)session.Load (typeof(PlayerEN), player.Id);



                playerEN.Name = player.Name;



                session.Update (playerEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PlayerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NewPlayer (PlayerEN player)
{
        try
        {
                SessionInitializeTransaction ();
                if (player.Sport != null) {
                        // Argumento OID y no colección.
                        player.Sport = (PickadosGenNHibernate.EN.Pickados.SportEN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.SportEN), player.Sport.Id);

                        player.Sport.Player
                        .Add (player);
                }

                session.Save (player);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PlayerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return player.Id;
}

public void ModifyPlayer (PlayerEN player)
{
        try
        {
                SessionInitializeTransaction ();
                PlayerEN playerEN = (PlayerEN)session.Load (typeof(PlayerEN), player.Id);

                playerEN.Name = player.Name;

                session.Update (playerEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PlayerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void DeletePlayer (int id
                          )
{
        try
        {
                SessionInitializeTransaction ();
                PlayerEN playerEN = (PlayerEN)session.Load (typeof(PlayerEN), id);
                session.Delete (playerEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PlayerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void JoinClubTeam (int p_Player_OID, int p_club_team_OID)
{
        PickadosGenNHibernate.EN.Pickados.PlayerEN playerEN = null;
        try
        {
                SessionInitializeTransaction ();
                playerEN = (PlayerEN)session.Load (typeof(PlayerEN), p_Player_OID);
                playerEN.Club_team = (PickadosGenNHibernate.EN.Pickados.TeamEN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.TeamEN), p_club_team_OID);

                playerEN.Club_team.Club_player.Add (playerEN);



                session.Update (playerEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PlayerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void JoinNationalTeam (int p_Player_OID, int p_national_team_OID)
{
        PickadosGenNHibernate.EN.Pickados.PlayerEN playerEN = null;
        try
        {
                SessionInitializeTransaction ();
                playerEN = (PlayerEN)session.Load (typeof(PlayerEN), p_Player_OID);
                playerEN.National_team = (PickadosGenNHibernate.EN.Pickados.TeamEN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.TeamEN), p_national_team_OID);

                playerEN.National_team.National_player.Add (playerEN);



                session.Update (playerEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PlayerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void UnlinkClubTeam (int p_Player_OID, int p_club_team_OID)
{
        try
        {
                SessionInitializeTransaction ();
                PickadosGenNHibernate.EN.Pickados.PlayerEN playerEN = null;
                playerEN = (PlayerEN)session.Load (typeof(PlayerEN), p_Player_OID);

                if (playerEN.Club_team.Id == p_club_team_OID) {
                        playerEN.Club_team = null;
                }
                else
                        throw new ModelException ("The identifier " + p_club_team_OID + " in p_club_team_OID you are trying to unrelationer, doesn't exist in PlayerEN");

                session.Update (playerEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PlayerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void UnlinkNationalTeam (int p_Player_OID, int p_national_team_OID)
{
        try
        {
                SessionInitializeTransaction ();
                PickadosGenNHibernate.EN.Pickados.PlayerEN playerEN = null;
                playerEN = (PlayerEN)session.Load (typeof(PlayerEN), p_Player_OID);

                if (playerEN.National_team.Id == p_national_team_OID) {
                        playerEN.National_team = null;
                }
                else
                        throw new ModelException ("The identifier " + p_national_team_OID + " in p_national_team_OID you are trying to unrelationer, doesn't exist in PlayerEN");

                session.Update (playerEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PlayerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
//Sin e: GetPlayerById
//Con e: PlayerEN
public PlayerEN GetPlayerById (int id
                               )
{
        PlayerEN playerEN = null;

        try
        {
                SessionInitializeTransaction ();
                playerEN = (PlayerEN)session.Get (typeof(PlayerEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PlayerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return playerEN;
}

public System.Collections.Generic.IList<PlayerEN> GetAllPlayers (int first, int size)
{
        System.Collections.Generic.IList<PlayerEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PlayerEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PlayerEN>();
                else
                        result = session.CreateCriteria (typeof(PlayerEN)).List<PlayerEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PlayerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PlayerEN> GetPlayersByClubTeam (string p_ClubTeam_Name, int first, int size)
{
        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PlayerEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PlayerEN self where SELECT p FROM PlayerEN as p INNER JOIN p.Club_team as t WHERE t.Name = :p_ClubTeam_Name";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PlayerENgetPlayersByClubTeamHQL");
                query.SetParameter ("p_ClubTeam_Name", p_ClubTeam_Name);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<PickadosGenNHibernate.EN.Pickados.PlayerEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PlayerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PlayerEN> GetPlayersByNationalTeam (string p_NationalTeam_Name)
{
        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PlayerEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PlayerEN self where SELECT p FROM PlayerEN as p INNER JOIN p.National_team as t WHERE t.Name = :p_NationalTeam_Name";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PlayerENgetPlayersByNationalTeamHQL");
                query.SetParameter ("p_NationalTeam_Name", p_NationalTeam_Name);

                result = query.List<PickadosGenNHibernate.EN.Pickados.PlayerEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PlayerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PlayerEN> GetPlayersNoClubTeam (int id)
{
        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PlayerEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PlayerEN self where select p FROM PlayerEN as p LEFT JOIN p.Club_team as t INNER JOIN p.Sport as s where t is null AND s.Id = :id";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PlayerENgetPlayersNoClubTeamHQL");
                query.SetParameter ("id", id);

                result = query.List<PickadosGenNHibernate.EN.Pickados.PlayerEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PlayerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PlayerEN> GetPlayersNoNationalTeam (int id)
{
        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PlayerEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PlayerEN self where select p FROM PlayerEN as p LEFT JOIN p.National_team as t INNER JOIN p.Sport as s where t is null AND s.Id =:id";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PlayerENgetPlayersNoNationalTeamHQL");
                query.SetParameter ("id", id);

                result = query.List<PickadosGenNHibernate.EN.Pickados.PlayerEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PlayerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
