

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

public void ModifyPost (int p_Post_OID, TimeSpan p_created_at, TimeSpan p_modified_at, double p_stake, string p_description, bool p_private, double p_totalOdd, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_postResult)
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

public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> GetPicks ()
{
        return _IPostCAD.GetPicks ();
}
public PostEN GetByID (int id
                       )
{
        PostEN postEN = null;

        postEN = _IPostCAD.GetByID (id);
        return postEN;
}

public System.Collections.Generic.IList<PostEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<PostEN> list = null;

        list = _IPostCAD.GetAll (first, size);
        return list;
}
public void AddPick (int p_Post_OID, System.Collections.Generic.IList<int> p_pick_OIDs)
{
        //Call to PostCAD

        _IPostCAD.AddPick (p_Post_OID, p_pick_OIDs);
}
}
}
