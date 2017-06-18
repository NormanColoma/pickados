
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
 * Clase Match:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial class MatchCAD : BasicCAD, IMatchCAD
{
public MatchCAD() : base ()
{
}

public MatchCAD(ISession sessionAux) : base (sessionAux)
{
}



public MatchEN ReadOIDDefault (int id
                               )
{
        MatchEN matchEN = null;

        try
        {
                SessionInitializeTransaction ();
                matchEN = (MatchEN)session.Get (typeof(MatchEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return matchEN;
}

public System.Collections.Generic.IList<MatchEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MatchEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MatchEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<MatchEN>();
                        else
                                result = session.CreateCriteria (typeof(MatchEN)).List<MatchEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MatchEN match)
{
        try
        {
                SessionInitializeTransaction ();
                MatchEN matchEN = (MatchEN)session.Load (typeof(MatchEN), match.Id);



                matchEN.Stadium = match.Stadium;

                session.Update (matchEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NewMatch (MatchEN match)
{
        try
        {
                SessionInitializeTransaction ();
                if (match.Round != null) {
                        // Argumento OID y no colección.
                        match.Round = (PickadosGenNHibernate.EN.Pickados.RoundEN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.RoundEN), match.Round.Id);

                        match.Round.Event_
                        .Add (match);
                }
                if (match.Away != null) {
                        // Argumento OID y no colección.
                        match.Away = (PickadosGenNHibernate.EN.Pickados.TeamEN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.TeamEN), match.Away.Id);

                        match.Away.Event_away
                        .Add (match);
                }
                if (match.Home != null) {
                        // Argumento OID y no colección.
                        match.Home = (PickadosGenNHibernate.EN.Pickados.TeamEN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.TeamEN), match.Home.Id);

                        match.Home.Event_home
                        .Add (match);
                }

                session.Save (match);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return match.Id;
}

public void ModifyMatch (MatchEN match)
{
        try
        {
                SessionInitializeTransaction ();
                MatchEN matchEN = (MatchEN)session.Load (typeof(MatchEN), match.Id);

                matchEN.Date = match.Date;


                matchEN.Stadium = match.Stadium;

                session.Update (matchEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void DeleteMatch (int id
                         )
{
        try
        {
                SessionInitializeTransaction ();
                MatchEN matchEN = (MatchEN)session.Load (typeof(MatchEN), id);
                session.Delete (matchEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: GetMatchById
//Con e: MatchEN
public MatchEN GetMatchById (int id
                             )
{
        MatchEN matchEN = null;

        try
        {
                SessionInitializeTransaction ();
                matchEN = (MatchEN)session.Get (typeof(MatchEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return matchEN;
}

public System.Collections.Generic.IList<MatchEN> GetAllMatches (int first, int size)
{
        System.Collections.Generic.IList<MatchEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MatchEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<MatchEN>();
                else
                        result = session.CreateCriteria (typeof(MatchEN)).List<MatchEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> GetMatchByCompetition (int id, int first, int size)
{
        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MatchEN self where select m FROM MatchEN as m INNER JOIN m.Competition as c where c.Id=:id";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MatchENgetMatchByCompetitionHQL");
                query.SetParameter ("id", id);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<PickadosGenNHibernate.EN.Pickados.MatchEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> GetMatchByLocalTeam (int id)
{
        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MatchEN self where select m FROM MatchEN as m INNER JOIN m.Home as t where t.Id=:id";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MatchENgetMatchByLocalTeamHQL");
                query.SetParameter ("id", id);

                result = query.List<PickadosGenNHibernate.EN.Pickados.MatchEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> GetMatchByVisistantTeam (int id)
{
        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MatchEN self where select m FROM MatchEN as m INNER JOIN m.Away as t where t.Id=:id";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MatchENgetMatchByVisistantTeamHQL");
                query.SetParameter ("id", id);

                result = query.List<PickadosGenNHibernate.EN.Pickados.MatchEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AddLocalTeamToMatch (int p_Match_OID, int p_home_OID)
{
        PickadosGenNHibernate.EN.Pickados.MatchEN matchEN = null;
        try
        {
                SessionInitializeTransaction ();
                matchEN = (MatchEN)session.Load (typeof(MatchEN), p_Match_OID);
                matchEN.Home = (PickadosGenNHibernate.EN.Pickados.TeamEN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.TeamEN), p_home_OID);

                matchEN.Home.Event_home.Add (matchEN);



                session.Update (matchEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void UnjoinLocalTeamToMatch (int p_Match_OID, int p_home_OID)
{
        try
        {
                SessionInitializeTransaction ();
                PickadosGenNHibernate.EN.Pickados.MatchEN matchEN = null;
                matchEN = (MatchEN)session.Load (typeof(MatchEN), p_Match_OID);

                if (matchEN.Home.Id == p_home_OID) {
                        matchEN.Home = null;
                }
                else
                        throw new ModelException ("The identifier " + p_home_OID + " in p_home_OID you are trying to unrelationer, doesn't exist in MatchEN");

                session.Update (matchEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AddAwayTeamToMatch (int p_Match_OID, int p_away_OID)
{
        PickadosGenNHibernate.EN.Pickados.MatchEN matchEN = null;
        try
        {
                SessionInitializeTransaction ();
                matchEN = (MatchEN)session.Load (typeof(MatchEN), p_Match_OID);
                matchEN.Away = (PickadosGenNHibernate.EN.Pickados.TeamEN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.TeamEN), p_away_OID);

                matchEN.Away.Event_away.Add (matchEN);



                session.Update (matchEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void UnjoinAwayTeamToMatch (int p_Match_OID, int p_away_OID)
{
        try
        {
                SessionInitializeTransaction ();
                PickadosGenNHibernate.EN.Pickados.MatchEN matchEN = null;
                matchEN = (MatchEN)session.Load (typeof(MatchEN), p_Match_OID);

                if (matchEN.Away.Id == p_away_OID) {
                        matchEN.Away = null;
                }
                else
                        throw new ModelException ("The identifier " + p_away_OID + " in p_away_OID you are trying to unrelationer, doesn't exist in MatchEN");

                session.Update (matchEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in MatchCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
