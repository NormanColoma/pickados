
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
 * Clase Competition:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial class CompetitionCAD : BasicCAD, ICompetitionCAD
{
public CompetitionCAD() : base ()
{
}

public CompetitionCAD(ISession sessionAux) : base (sessionAux)
{
}



public CompetitionEN ReadOIDDefault (int id
                                     )
{
        CompetitionEN competitionEN = null;

        try
        {
                SessionInitializeTransaction ();
                competitionEN = (CompetitionEN)session.Get (typeof(CompetitionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in CompetitionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return competitionEN;
}

public System.Collections.Generic.IList<CompetitionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CompetitionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CompetitionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CompetitionEN>();
                        else
                                result = session.CreateCriteria (typeof(CompetitionEN)).List<CompetitionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in CompetitionCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CompetitionEN competition)
{
        try
        {
                SessionInitializeTransaction ();
                CompetitionEN competitionEN = (CompetitionEN)session.Load (typeof(CompetitionEN), competition.Id);

                competitionEN.Name = competition.Name;




                competitionEN.Place = competition.Place;


                session.Update (competitionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in CompetitionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NewCompetition (CompetitionEN competition)
{
        try
        {
                SessionInitializeTransaction ();
                if (competition.Sport != null) {
                        // Argumento OID y no colección.
                        competition.Sport = (PickadosGenNHibernate.EN.Pickados.SportEN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.SportEN), competition.Sport.Id);

                        competition.Sport.Competition
                        .Add (competition);
                }

                session.Save (competition);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in CompetitionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return competition.Id;
}

public void ModifyCompetition (CompetitionEN competition)
{
        try
        {
                SessionInitializeTransaction ();
                CompetitionEN competitionEN = (CompetitionEN)session.Load (typeof(CompetitionEN), competition.Id);

                competitionEN.Name = competition.Name;


                competitionEN.Place = competition.Place;

                session.Update (competitionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in CompetitionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void DeleteCompetition (int id
                               )
{
        try
        {
                SessionInitializeTransaction ();
                CompetitionEN competitionEN = (CompetitionEN)session.Load (typeof(CompetitionEN), id);
                session.Delete (competitionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in CompetitionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> GetCompetitionsByPlace (string place)
{
        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CompetitionEN self where FROM CompetitionEN WHERE Place = :place";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CompetitionENgetCompetitionsByPlaceHQL");
                query.SetParameter ("place", place);

                result = query.List<PickadosGenNHibernate.EN.Pickados.CompetitionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in CompetitionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
//Sin e: GetCompetitionById
//Con e: CompetitionEN
public CompetitionEN GetCompetitionById (int id
                                         )
{
        CompetitionEN competitionEN = null;

        try
        {
                SessionInitializeTransaction ();
                competitionEN = (CompetitionEN)session.Get (typeof(CompetitionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in CompetitionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return competitionEN;
}

public System.Collections.Generic.IList<CompetitionEN> GetAllCompetitions (int first, int size)
{
        System.Collections.Generic.IList<CompetitionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CompetitionEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CompetitionEN>();
                else
                        result = session.CreateCriteria (typeof(CompetitionEN)).List<CompetitionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in CompetitionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> GetCompetitionByTeam (int id)
{
        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CompetitionEN self where select c FROM CompetitionEN as c INNER JOIN c.Team as t where t.Id=:id";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CompetitionENgetCompetitionByTeamHQL");
                query.SetParameter ("id", id);

                result = query.List<PickadosGenNHibernate.EN.Pickados.CompetitionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in CompetitionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
