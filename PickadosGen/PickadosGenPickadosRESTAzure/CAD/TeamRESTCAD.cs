
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
public class TeamRESTCAD : TeamCAD
{
public TeamRESTCAD()
        : base ()
{
}

public TeamRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<PlayerEN> GetAllClub_playerOfClub_team (int id)
{
        IList<PlayerEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self.Club_player FROM TeamEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);


                result = query.List<PlayerEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException) throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TeamRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public IList<PlayerEN> GetAllNational_playerOfNational_team (int id)
{
        IList<PlayerEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self.National_player FROM TeamEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);


                result = query.List<PlayerEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException) throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TeamRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
