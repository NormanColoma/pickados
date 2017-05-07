
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



/*PROTECTED REGION ID(usingPickadosGenNHibernate.CP.Pickados_Tipster_getTipstersPremium) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PickadosGenNHibernate.CP.Pickados
{
public partial class TipsterCP : BasicCP
{
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> GetTipstersPremium (int? first, int ? size)
{
        /*PROTECTED REGION ID(PickadosGenNHibernate.CP.Pickados_Tipster_getTipstersPremium) ENABLED START*/

        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM TipsterEN self where FROM TipsterEN where Premium=true";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("TipsterENgetTipstersPremiumHQL");
                query.SetFirstResult (Convert.ToInt32 (first));
                query.SetMaxResults (Convert.ToInt32 (size));

                result = query.List<PickadosGenNHibernate.EN.Pickados.TipsterEN>();
                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TipsterCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;


        /*PROTECTED REGION END*/
}
}
}
