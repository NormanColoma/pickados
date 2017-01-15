
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
 * Clase Team:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial class TeamCAD : BasicCAD, ITeamCAD
{
public TeamCAD() : base ()
{
}

public TeamCAD(ISession sessionAux) : base (sessionAux)
{
}



public TeamEN ReadOIDDefault (int id
                              )
{
        TeamEN teamEN = null;

        try
        {
                SessionInitializeTransaction ();
                teamEN = (TeamEN)session.Get (typeof(TeamEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TeamCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return teamEN;
}

public System.Collections.Generic.IList<TeamEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<TeamEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(TeamEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<TeamEN>();
                        else
                                result = session.CreateCriteria (typeof(TeamEN)).List<TeamEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TeamCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (TeamEN team)
{
        try
        {
                SessionInitializeTransaction ();
                TeamEN teamEN = (TeamEN)session.Load (typeof(TeamEN), team.Id);

                teamEN.Name = team.Name;


                teamEN.Country = team.Country;





                session.Update (teamEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TeamCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NewTeam (TeamEN team)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (team);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TeamCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return team.Id;
}

public void ModifyTeam (TeamEN team)
{
        try
        {
                SessionInitializeTransaction ();
                TeamEN teamEN = (TeamEN)session.Load (typeof(TeamEN), team.Id);

                teamEN.Name = team.Name;


                teamEN.Country = team.Country;

                session.Update (teamEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TeamCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void DeleteTeam (int id
                        )
{
        try
        {
                SessionInitializeTransaction ();
                TeamEN teamEN = (TeamEN)session.Load (typeof(TeamEN), id);
                session.Delete (teamEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TeamCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
