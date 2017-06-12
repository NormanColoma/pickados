
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
 * Clase Season:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial class SeasonCAD : BasicCAD, ISeasonCAD
{
public SeasonCAD() : base ()
{
}

public SeasonCAD(ISession sessionAux) : base (sessionAux)
{
}



public SeasonEN ReadOIDDefault (int id
                                )
{
        SeasonEN seasonEN = null;

        try
        {
                SessionInitializeTransaction ();
                seasonEN = (SeasonEN)session.Get (typeof(SeasonEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in SeasonCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return seasonEN;
}

public System.Collections.Generic.IList<SeasonEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<SeasonEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(SeasonEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<SeasonEN>();
                        else
                                result = session.CreateCriteria (typeof(SeasonEN)).List<SeasonEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in SeasonCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (SeasonEN season)
{
        try
        {
                SessionInitializeTransaction ();
                SeasonEN seasonEN = (SeasonEN)session.Load (typeof(SeasonEN), season.Id);

                seasonEN.InitDate = season.InitDate;


                seasonEN.FinalDate = season.FinalDate;



                session.Update (seasonEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in SeasonCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NewSeason (SeasonEN season)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (season);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in SeasonCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return season.Id;
}

public void ModifySeason (SeasonEN season)
{
        try
        {
                SessionInitializeTransaction ();
                SeasonEN seasonEN = (SeasonEN)session.Load (typeof(SeasonEN), season.Id);

                seasonEN.InitDate = season.InitDate;


                seasonEN.FinalDate = season.FinalDate;

                session.Update (seasonEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in SeasonCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void DestroySeason (int id
                           )
{
        try
        {
                SessionInitializeTransaction ();
                SeasonEN seasonEN = (SeasonEN)session.Load (typeof(SeasonEN), id);
                session.Delete (seasonEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in SeasonCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: GetSeasonByID
//Con e: SeasonEN
public SeasonEN GetSeasonByID (int id
                               )
{
        SeasonEN seasonEN = null;

        try
        {
                SessionInitializeTransaction ();
                seasonEN = (SeasonEN)session.Get (typeof(SeasonEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in SeasonCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return seasonEN;
}

public System.Collections.Generic.IList<SeasonEN> GetAllSeasons (int first, int size)
{
        System.Collections.Generic.IList<SeasonEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(SeasonEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<SeasonEN>();
                else
                        result = session.CreateCriteria (typeof(SeasonEN)).List<SeasonEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in SeasonCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.SeasonEN> GetSeasonByCompetition (int id)
{
        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.SeasonEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SeasonEN self where select s FROM SeasonEN as s INNER JOIN s.Competition as c where c.Id = :id";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SeasonENGetSeasonByCompetitionHQL");
                query.SetParameter ("id", id);

                result = query.List<PickadosGenNHibernate.EN.Pickados.SeasonEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in SeasonCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
