
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
 * Clase Login:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial class LoginCAD : BasicCAD, ILoginCAD
{
public LoginCAD() : base ()
{
}

public LoginCAD(ISession sessionAux) : base (sessionAux)
{
}



public LoginEN ReadOIDDefault (int id
                               )
{
        LoginEN loginEN = null;

        try
        {
                SessionInitializeTransaction ();
                loginEN = (LoginEN)session.Get (typeof(LoginEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in LoginCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return loginEN;
}

public System.Collections.Generic.IList<LoginEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LoginEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LoginEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<LoginEN>();
                        else
                                result = session.CreateCriteria (typeof(LoginEN)).List<LoginEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in LoginCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (LoginEN login)
{
        try
        {
                SessionInitializeTransaction ();
                LoginEN loginEN = (LoginEN)session.Load (typeof(LoginEN), login.Id);

                loginEN.Alias = login.Alias;


                loginEN.Date = login.Date;

                session.Update (loginEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in LoginCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NewLogin (LoginEN login)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (login);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in LoginCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return login.Id;
}

public System.Collections.Generic.IList<LoginEN> GetAllLogins (int first, int size)
{
        System.Collections.Generic.IList<LoginEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(LoginEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<LoginEN>();
                else
                        result = session.CreateCriteria (typeof(LoginEN)).List<LoginEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in LoginCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.LoginEN> GetLoginBetweenMonths (Nullable<DateTime> initialDate, Nullable<DateTime> finalDate)
{
        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.LoginEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM LoginEN self where FROM LoginEN WHERE date BETWEEN :initialDate and :finalDate";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("LoginENgetLoginBetweenMonthsHQL");
                query.SetParameter ("initialDate", initialDate);
                query.SetParameter ("finalDate", finalDate);

                result = query.List<PickadosGenNHibernate.EN.Pickados.LoginEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in LoginCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
