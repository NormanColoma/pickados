
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
 * Clase Round:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial class RoundCAD : BasicCAD, IRoundCAD
{
public RoundCAD() : base ()
{
}

public RoundCAD(ISession sessionAux) : base (sessionAux)
{
}



public RoundEN ReadOIDDefault (int id
                               )
{
        RoundEN roundEN = null;

        try
        {
                SessionInitializeTransaction ();
                roundEN = (RoundEN)session.Get (typeof(RoundEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in RoundCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return roundEN;
}

public System.Collections.Generic.IList<RoundEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<RoundEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(RoundEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<RoundEN>();
                        else
                                result = session.CreateCriteria (typeof(RoundEN)).List<RoundEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in RoundCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (RoundEN round)
{
        try
        {
                SessionInitializeTransaction ();
                RoundEN roundEN = (RoundEN)session.Load (typeof(RoundEN), round.Id);



                roundEN.Name = round.Name;

                session.Update (roundEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in RoundCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NewRound (RoundEN round)
{
        try
        {
                SessionInitializeTransaction ();
                if (round.Season != null) {
                        // Argumento OID y no colección.
                        round.Season = (PickadosGenNHibernate.EN.Pickados.SeasonEN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.SeasonEN), round.Season.Id);

                        round.Season.Round
                        .Add (round);
                }

                session.Save (round);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in RoundCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return round.Id;
}

public void ModifyRound (RoundEN round)
{
        try
        {
                SessionInitializeTransaction ();
                RoundEN roundEN = (RoundEN)session.Load (typeof(RoundEN), round.Id);

                roundEN.Name = round.Name;

                session.Update (roundEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in RoundCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void DestroyRound (int id
                          )
{
        try
        {
                SessionInitializeTransaction ();
                RoundEN roundEN = (RoundEN)session.Load (typeof(RoundEN), id);
                session.Delete (roundEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in RoundCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: RoundEN
public RoundEN ReadOID (int id
                        )
{
        RoundEN roundEN = null;

        try
        {
                SessionInitializeTransaction ();
                roundEN = (RoundEN)session.Get (typeof(RoundEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in RoundCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return roundEN;
}

public System.Collections.Generic.IList<RoundEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RoundEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(RoundEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<RoundEN>();
                else
                        result = session.CreateCriteria (typeof(RoundEN)).List<RoundEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in RoundCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.RoundEN> GetRoundBySeason (int id)
{
        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.RoundEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RoundEN self where select r FROM RoundEN as r INNER JOIN r.Season as s WHERE s.Id = :id";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RoundENgetRoundBySeasonHQL");
                query.SetParameter ("id", id);

                result = query.List<PickadosGenNHibernate.EN.Pickados.RoundEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in RoundCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
