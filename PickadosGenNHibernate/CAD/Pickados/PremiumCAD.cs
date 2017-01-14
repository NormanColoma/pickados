
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
 * Clase Premium:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial class PremiumCAD : BasicCAD, IPremiumCAD
{
public PremiumCAD() : base ()
{
}

public PremiumCAD(ISession sessionAux) : base (sessionAux)
{
}



public PremiumEN ReadOIDDefault (int id
                                 )
{
        PremiumEN premiumEN = null;

        try
        {
                SessionInitializeTransaction ();
                premiumEN = (PremiumEN)session.Get (typeof(PremiumEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PremiumCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return premiumEN;
}

public System.Collections.Generic.IList<PremiumEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PremiumEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PremiumEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PremiumEN>();
                        else
                                result = session.CreateCriteria (typeof(PremiumEN)).List<PremiumEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PremiumCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PremiumEN premium)
{
        try
        {
                SessionInitializeTransaction ();
                PremiumEN premiumEN = (PremiumEN)session.Load (typeof(PremiumEN), premium.Id);

                premiumEN.Subscription_fee = premium.Subscription_fee;

                session.Update (premiumEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PremiumCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PremiumEN premium)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (premium);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PremiumCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return premium.Id;
}

public void Modify (PremiumEN premium)
{
        try
        {
                SessionInitializeTransaction ();
                PremiumEN premiumEN = (PremiumEN)session.Load (typeof(PremiumEN), premium.Id);

                premiumEN.CreatedAt = premium.CreatedAt;


                premiumEN.ModifiedAt = premium.ModifiedAt;


                premiumEN.Alias = premium.Alias;


                premiumEN.Email = premium.Email;


                premiumEN.Password = premium.Password;


                premiumEN.Subscription_fee = premium.Subscription_fee;

                session.Update (premiumEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PremiumCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                PremiumEN premiumEN = (PremiumEN)session.Load (typeof(PremiumEN), id);
                session.Delete (premiumEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PremiumCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
