
using System;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using System.Collections.Generic;

using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CAD.Pickados;
using PickadosGenNHibernate.CEN.Pickados;

namespace PickadosGenPickadosRESTAzure.CAD
{
public class MatchRESTCAD : MatchCAD
{
public MatchRESTCAD()
        : base ()
{
}

public MatchRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public TeamEN GetHomeOfEvent_home (int id)
{
        TeamEN result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self.Home FROM MatchEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);


                result = query.UniqueResult<TeamEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException) throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in MatchRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public TeamEN GetAwayOfEvent_away (int id)
{
        TeamEN result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self.Away FROM MatchEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);


                result = query.UniqueResult<TeamEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException) throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in MatchRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
