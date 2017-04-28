
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
public class CompetitionRESTCAD : CompetitionCAD
{
public CompetitionRESTCAD()
        : base ()
{
}

public CompetitionRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<MatchEN> GetAllEventOfCompetition (int id)
{
        IList<MatchEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self.Event_ FROM CompetitionEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);


                result = query.List<MatchEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException) throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in CompetitionRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
