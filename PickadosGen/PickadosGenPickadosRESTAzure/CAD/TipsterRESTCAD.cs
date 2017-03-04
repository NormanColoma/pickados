
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
public class TipsterRESTCAD : TipsterCAD
{
public TipsterRESTCAD()
        : base ()
{
}

public TipsterRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<PostEN> GetAllPostOfTipster (int id)
{
        IList<PostEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self.Post FROM TipsterEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);


                result = query.List<PostEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException) throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TipsterRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
