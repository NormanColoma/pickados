

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PickadosGenNHibernate.Exceptions;

using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CAD.Pickados;


namespace PickadosGenNHibernate.CEN.Pickados
{
/*
 *      Definition of the class PostCEN
 *
 */
public partial class PostCEN
{
private IPostCAD _IPostCAD;

public PostCEN()
{
        this._IPostCAD = new PostCAD ();
}

public PostCEN(IPostCAD _IPostCAD)
{
        this._IPostCAD = _IPostCAD;
}

public IPostCAD get_IPostCAD ()
{
        return this._IPostCAD;
}

public void ModifyPost (int p_Post_OID, Nullable<DateTime> p_created_at, Nullable<DateTime> p_modified_at, double p_stake, string p_description, bool p_private, double p_totalOdd, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_postResult)
{
        PostEN postEN = null;

        //Initialized PostEN
        postEN = new PostEN ();
        postEN.Id = p_Post_OID;
        postEN.Created_at = p_created_at;
        postEN.Modified_at = p_modified_at;
        postEN.Stake = p_stake;
        postEN.Description = p_description;
        postEN.Private_ = p_private;
        postEN.TotalOdd = p_totalOdd;
        postEN.PostResult = p_postResult;
        //Call to PostCAD

        _IPostCAD.ModifyPost (postEN);
}

public void DeletePost (int id
                        )
{
        _IPostCAD.DeletePost (id);
}

public PostEN GetPostById (int id
                           )
{
        PostEN postEN = null;

        postEN = _IPostCAD.GetPostById (id);
        return postEN;
}

public System.Collections.Generic.IList<PostEN> GetAllPosts (int first, int size)
{
        System.Collections.Generic.IList<PostEN> list = null;

        list = _IPostCAD.GetAllPosts (first, size);
        return list;
}
public int NewPost (Nullable<DateTime> p_created_at, Nullable<DateTime> p_modified_at, double p_stake, string p_description, bool p_private, System.Collections.Generic.IList<int> p_pick, int p_tipster, double p_totalOdd, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_postResult)
{
        PostEN postEN = null;
        int oid;

        //Initialized PostEN
        postEN = new PostEN ();
        postEN.Created_at = p_created_at;

        postEN.Modified_at = p_modified_at;

        postEN.Stake = p_stake;

        postEN.Description = p_description;

        postEN.Private_ = p_private;


        postEN.Pick = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.PickEN>();
        if (p_pick != null) {
                foreach (int item in p_pick) {
                        PickadosGenNHibernate.EN.Pickados.PickEN en = new PickadosGenNHibernate.EN.Pickados.PickEN ();
                        en.Id = item;
                        postEN.Pick.Add (en);
                }
        }

        else{
                postEN.Pick = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.PickEN>();
        }


        if (p_tipster != -1) {
                // El argumento p_tipster -> Property tipster es oid = false
                // Lista de oids id
                postEN.Tipster = new PickadosGenNHibernate.EN.Pickados.TipsterEN ();
                postEN.Tipster.Id = p_tipster;
        }

        postEN.TotalOdd = p_totalOdd;

        postEN.PostResult = p_postResult;

        //Call to PostCAD

        oid = _IPostCAD.NewPost (postEN);
        return oid;
}

public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> GetAllPostsByResult (PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum ? postResult)
{
        return _IPostCAD.GetAllPostsByResult (postResult);
}
}
}
