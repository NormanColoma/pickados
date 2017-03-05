
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
public class Sport_2RESTCAD : SportCAD
{
public Sport_2RESTCAD()
        : base ()
{
}

public Sport_2RESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<CompetitionEN> GetAllCompetitionOfSport (int id)
{
        IList<CompetitionEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self.Competition FROM SportEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);


                result = query.List<CompetitionEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException) throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in SportRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
