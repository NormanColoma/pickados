
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
 * Clase Tipster:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial class TipsterCAD : BasicCAD, ITipsterCAD
{
public TipsterCAD() : base ()
{
}

public TipsterCAD(ISession sessionAux) : base (sessionAux)
{
}



public TipsterEN ReadOIDDefault (int id
                                 )
{
        TipsterEN tipsterEN = null;

        try
        {
                SessionInitializeTransaction ();
                tipsterEN = (TipsterEN)session.Get (typeof(TipsterEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TipsterCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tipsterEN;
}

public System.Collections.Generic.IList<TipsterEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<TipsterEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(TipsterEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<TipsterEN>();
                        else
                                result = session.CreateCriteria (typeof(TipsterEN)).List<TipsterEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TipsterCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (TipsterEN tipster)
{
        try
        {
                SessionInitializeTransaction ();
                TipsterEN tipsterEN = (TipsterEN)session.Load (typeof(TipsterEN), tipster.Id);





                tipsterEN.Premium = tipster.Premium;


                tipsterEN.Subscription_fee = tipster.Subscription_fee;

                session.Update (tipsterEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TipsterCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NewTipster (TipsterEN tipster)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (tipster);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TipsterCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tipster.Id;
}

public void ModifyTipster (TipsterEN tipster)
{
        try
        {
                SessionInitializeTransaction ();
                TipsterEN tipsterEN = (TipsterEN)session.Load (typeof(TipsterEN), tipster.Id);

                tipsterEN.Alias = tipster.Alias;


                tipsterEN.Email = tipster.Email;


                tipsterEN.Password = tipster.Password;


                tipsterEN.Created_at = tipster.Created_at;


                tipsterEN.Updated_at = tipster.Updated_at;


                tipsterEN.Nif = tipster.Nif;


                tipsterEN.Premium = tipster.Premium;


                tipsterEN.Subscription_fee = tipster.Subscription_fee;

                session.Update (tipsterEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TipsterCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void DeleteTipster (int id
                           )
{
        try
        {
                SessionInitializeTransaction ();
                TipsterEN tipsterEN = (TipsterEN)session.Load (typeof(TipsterEN), id);
                session.Delete (tipsterEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TipsterCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> GetFollowers (int id)
{
        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM TipsterEN self where select t1 FROM TipsterEN as t INNER JOIN t.Followed_by as t1 where t.Id=:id";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("TipsterENgetFollowersHQL");
                query.SetParameter ("id", id);

                result = query.List<PickadosGenNHibernate.EN.Pickados.TipsterEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
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
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> GetPosts ()
{
        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM TipsterEN self where SELECT post FROM PostEN as post, TipsterEN as tipster WHERE post.Tipster.Id = tipster.Id ";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("TipsterENgetPostsHQL");

                result = query.List<PickadosGenNHibernate.EN.Pickados.PostEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
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
}
public void AddFollower (int p_Tipster_OID, System.Collections.Generic.IList<int> p_followed_by_OIDs)
{
        PickadosGenNHibernate.EN.Pickados.TipsterEN tipsterEN = null;
        try
        {
                SessionInitializeTransaction ();
                tipsterEN = (TipsterEN)session.Load (typeof(TipsterEN), p_Tipster_OID);
                PickadosGenNHibernate.EN.Pickados.TipsterEN followed_byENAux = null;
                if (tipsterEN.Followed_by == null) {
                        tipsterEN.Followed_by = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.TipsterEN>();
                }

                foreach (int item in p_followed_by_OIDs) {
                        followed_byENAux = new PickadosGenNHibernate.EN.Pickados.TipsterEN ();
                        followed_byENAux = (PickadosGenNHibernate.EN.Pickados.TipsterEN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.TipsterEN), item);
                        followed_byENAux.Follow_to.Add (tipsterEN);

                        tipsterEN.Followed_by.Add (followed_byENAux);
                }


                session.Update (tipsterEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TipsterCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: GetTipsterById
//Con e: TipsterEN
public TipsterEN GetTipsterById (int id
                                 )
{
        TipsterEN tipsterEN = null;

        try
        {
                SessionInitializeTransaction ();
                tipsterEN = (TipsterEN)session.Get (typeof(TipsterEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TipsterCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tipsterEN;
}

public System.Collections.Generic.IList<TipsterEN> GetAllTipsters (int first, int size)
{
        System.Collections.Generic.IList<TipsterEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(TipsterEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<TipsterEN>();
                else
                        result = session.CreateCriteria (typeof(TipsterEN)).List<TipsterEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
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
}

public void AddFollow (int p_Tipster_OID, System.Collections.Generic.IList<int> p_follow_to_OIDs)
{
        PickadosGenNHibernate.EN.Pickados.TipsterEN tipsterEN = null;
        try
        {
                SessionInitializeTransaction ();
                tipsterEN = (TipsterEN)session.Load (typeof(TipsterEN), p_Tipster_OID);
                PickadosGenNHibernate.EN.Pickados.TipsterEN follow_toENAux = null;
                if (tipsterEN.Follow_to == null) {
                        tipsterEN.Follow_to = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.TipsterEN>();
                }

                foreach (int item in p_follow_to_OIDs) {
                        follow_toENAux = new PickadosGenNHibernate.EN.Pickados.TipsterEN ();
                        follow_toENAux = (PickadosGenNHibernate.EN.Pickados.TipsterEN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.TipsterEN), item);
                        follow_toENAux.Followed_by.Add (tipsterEN);

                        tipsterEN.Follow_to.Add (follow_toENAux);
                }


                session.Update (tipsterEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TipsterCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> GetFollows (int ? id)
{
        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM TipsterEN self where select t1 FROM TipsterEN as t INNER JOIN t.Follow_to as t1 where t.Id=:id";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("TipsterENgetFollowsHQL");
                query.SetParameter ("id", id);

                result = query.List<PickadosGenNHibernate.EN.Pickados.TipsterEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
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
}
public void DeleteFollow (int p_Tipster_OID, System.Collections.Generic.IList<int> p_followed_by_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                PickadosGenNHibernate.EN.Pickados.TipsterEN tipsterEN = null;
                tipsterEN = (TipsterEN)session.Load (typeof(TipsterEN), p_Tipster_OID);

                PickadosGenNHibernate.EN.Pickados.TipsterEN followed_byENAux = null;
                if (tipsterEN.Followed_by != null) {
                        foreach (int item in p_followed_by_OIDs) {
                                followed_byENAux = (PickadosGenNHibernate.EN.Pickados.TipsterEN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.TipsterEN), item);
                                if (tipsterEN.Followed_by.Contains (followed_byENAux) == true) {
                                        tipsterEN.Followed_by.Remove (followed_byENAux);
                                        followed_byENAux.Follow_to.Remove (tipsterEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_followed_by_OIDs you are trying to unrelationer, doesn't exist in TipsterEN");
                        }
                }

                session.Update (tipsterEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TipsterCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> GetTipstersWithBenefit ()
{
        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM TipsterEN self where FROM TipsterEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("TipsterENgetTipstersWithBenefitHQL");

                result = query.List<PickadosGenNHibernate.EN.Pickados.TipsterEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
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
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> GetStatsByMonth (Nullable<DateTime> p_date)
{
        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM TipsterEN self where FROM TipsterEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("TipsterENgetStatsByMonthHQL");
                query.SetParameter ("p_date", p_date);

                result = query.List<PickadosGenNHibernate.EN.Pickados.TipsterEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
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
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> GetTipstersPremium ()
{
        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM TipsterEN self where FROM TipsterEN where Premium=true";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("TipsterENgetTipstersPremiumHQL");

                result = query.List<PickadosGenNHibernate.EN.Pickados.TipsterEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
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
}
}
}
