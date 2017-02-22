
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
 * Clase Post:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial class PostCAD : BasicCAD, IPostCAD
{
public PostCAD() : base ()
{
}

public PostCAD(ISession sessionAux) : base (sessionAux)
{
}



public PostEN ReadOIDDefault (int id
                              )
{
        PostEN postEN = null;

        try
        {
                SessionInitializeTransaction ();
                postEN = (PostEN)session.Get (typeof(PostEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return postEN;
}

public System.Collections.Generic.IList<PostEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PostEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PostEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PostEN>();
                        else
                                result = session.CreateCriteria (typeof(PostEN)).List<PostEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PostEN post)
{
        try
        {
                SessionInitializeTransaction ();
                PostEN postEN = (PostEN)session.Load (typeof(PostEN), post.Id);

                postEN.Created_at = post.Created_at;


                postEN.Modified_at = post.Modified_at;


                postEN.Stake = post.Stake;


                postEN.Description = post.Description;


                postEN.Private_ = post.Private_;




                postEN.TotalOdd = post.TotalOdd;


                postEN.PostResult = post.PostResult;

                session.Update (postEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void ModifyPost (PostEN post)
{
        try
        {
                SessionInitializeTransaction ();
                PostEN postEN = (PostEN)session.Load (typeof(PostEN), post.Id);

                postEN.Created_at = post.Created_at;


                postEN.Modified_at = post.Modified_at;


                postEN.Stake = post.Stake;


                postEN.Description = post.Description;


                postEN.Private_ = post.Private_;


                postEN.TotalOdd = post.TotalOdd;


                postEN.PostResult = post.PostResult;

                session.Update (postEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void DeletePost (int id
                        )
{
        try
        {
                SessionInitializeTransaction ();
                PostEN postEN = (PostEN)session.Load (typeof(PostEN), id);
                session.Delete (postEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: GetPostById
//Con e: PostEN
public PostEN GetPostById (int id
                           )
{
        PostEN postEN = null;

        try
        {
                SessionInitializeTransaction ();
                postEN = (PostEN)session.Get (typeof(PostEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return postEN;
}

public System.Collections.Generic.IList<PostEN> GetAllPosts (int first, int size)
{
        System.Collections.Generic.IList<PostEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PostEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PostEN>();
                else
                        result = session.CreateCriteria (typeof(PostEN)).List<PostEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public int NewPost (PostEN post)
{
        try
        {
                SessionInitializeTransaction ();
                if (post.Pick != null) {
                        for (int i = 0; i < post.Pick.Count; i++) {
                                post.Pick [i] = (PickadosGenNHibernate.EN.Pickados.PickEN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.PickEN), post.Pick [i].Id);
                                post.Pick [i].Post.Add (post);
                        }
                }
                if (post.Tipster != null) {
                        // Argumento OID y no colección.
                        post.Tipster = (PickadosGenNHibernate.EN.Pickados.TipsterEN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.TipsterEN), post.Tipster.Id);

                        post.Tipster.Post
                        .Add (post);
                }

                session.Save (post);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return post.Id;
}
}
}
