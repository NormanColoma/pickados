

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
 *      Definition of the class TipsterCEN
 *
 */
public partial class TipsterCEN
{
private ITipsterCAD _ITipsterCAD;

public TipsterCEN()
{
        this._ITipsterCAD = new TipsterCAD ();
}

public TipsterCEN(ITipsterCAD _ITipsterCAD)
{
        this._ITipsterCAD = _ITipsterCAD;
}

public ITipsterCAD get_ITipsterCAD ()
{
        return this._ITipsterCAD;
}

public int NewTipster (TimeSpan p_createdAt, TimeSpan p_modifiedAt, string p_alias, string p_email, String p_password, bool p_premium, double p_subscription_fee)
{
        TipsterEN tipsterEN = null;
        int oid;

        //Initialized TipsterEN
        tipsterEN = new TipsterEN ();
        tipsterEN.CreatedAt = p_createdAt;

        tipsterEN.ModifiedAt = p_modifiedAt;

        tipsterEN.Alias = p_alias;

        tipsterEN.Email = p_email;

        tipsterEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        tipsterEN.Premium = p_premium;

        tipsterEN.Subscription_fee = p_subscription_fee;

        //Call to TipsterCAD

        oid = _ITipsterCAD.NewTipster (tipsterEN);
        return oid;
}

public void ModifyTipster (int p_Tipster_OID, TimeSpan p_createdAt, TimeSpan p_modifiedAt, string p_alias, string p_email, String p_password, bool p_premium, double p_subscription_fee)
{
        TipsterEN tipsterEN = null;

        //Initialized TipsterEN
        tipsterEN = new TipsterEN ();
        tipsterEN.Id = p_Tipster_OID;
        tipsterEN.CreatedAt = p_createdAt;
        tipsterEN.ModifiedAt = p_modifiedAt;
        tipsterEN.Alias = p_alias;
        tipsterEN.Email = p_email;
        tipsterEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        tipsterEN.Premium = p_premium;
        tipsterEN.Subscription_fee = p_subscription_fee;
        //Call to TipsterCAD

        _ITipsterCAD.ModifyTipster (tipsterEN);
}

public void DeleteTipster (int id
                           )
{
        _ITipsterCAD.DeleteTipster (id);
}

public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> GetFollowers ()
{
        return _ITipsterCAD.GetFollowers ();
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> GetPosts ()
{
        return _ITipsterCAD.GetPosts ();
}
public void AddFollower (int p_Tipster_OID, System.Collections.Generic.IList<int> p_followed_by_OIDs)
{
        //Call to TipsterCAD

        _ITipsterCAD.AddFollower (p_Tipster_OID, p_followed_by_OIDs);
}
public TipsterEN GetByID (int id
                          )
{
        TipsterEN tipsterEN = null;

        tipsterEN = _ITipsterCAD.GetByID (id);
        return tipsterEN;
}

public System.Collections.Generic.IList<TipsterEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<TipsterEN> list = null;

        list = _ITipsterCAD.GetAll (first, size);
        return list;
}
public void AddFollow (int p_Tipster_OID, System.Collections.Generic.IList<int> p_follow_to_OIDs)
{
        //Call to TipsterCAD

        _ITipsterCAD.AddFollow (p_Tipster_OID, p_follow_to_OIDs);
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> GetFollows ()
{
        return _ITipsterCAD.GetFollows ();
}
public void DeleteFollow (int p_Tipster_OID, System.Collections.Generic.IList<int> p_follow_to_OIDs)
{
        //Call to TipsterCAD

        _ITipsterCAD.DeleteFollow (p_Tipster_OID, p_follow_to_OIDs);
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> GetTipstersWithBenefit ()
{
        return _ITipsterCAD.GetTipstersWithBenefit ();
}
}
}
