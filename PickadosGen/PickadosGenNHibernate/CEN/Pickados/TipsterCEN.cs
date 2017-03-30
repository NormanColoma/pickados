

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

public int NewTipster (string p_alias, string p_email, String p_password, Nullable<DateTime> p_created_at, Nullable<DateTime> p_updated_at, string p_nif, bool p_admin, bool p_premium, double p_subscription_fee)
{
        TipsterEN tipsterEN = null;
        int oid;

        //Initialized TipsterEN
        tipsterEN = new TipsterEN ();
        tipsterEN.Alias = p_alias;

        tipsterEN.Email = p_email;

        tipsterEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        tipsterEN.Created_at = p_created_at;

        tipsterEN.Updated_at = p_updated_at;

        tipsterEN.Nif = p_nif;

        tipsterEN.Admin = p_admin;

        tipsterEN.Premium = p_premium;

        tipsterEN.Subscription_fee = p_subscription_fee;

        //Call to TipsterCAD

        oid = _ITipsterCAD.NewTipster (tipsterEN);
        return oid;
}

public void ModifyTipster (int p_Tipster_OID, string p_alias, string p_email, String p_password, Nullable<DateTime> p_created_at, Nullable<DateTime> p_updated_at, string p_nif, bool p_admin, bool p_premium, double p_subscription_fee)
{
        TipsterEN tipsterEN = null;

        //Initialized TipsterEN
        tipsterEN = new TipsterEN ();
        tipsterEN.Id = p_Tipster_OID;
        tipsterEN.Alias = p_alias;
        tipsterEN.Email = p_email;
        tipsterEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        tipsterEN.Created_at = p_created_at;
        tipsterEN.Updated_at = p_updated_at;
        tipsterEN.Nif = p_nif;
        tipsterEN.Admin = p_admin;
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

public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> GetFollowers (int id)
{
        return _ITipsterCAD.GetFollowers (id);
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
public TipsterEN GetTipsterById (int id
                                 )
{
        TipsterEN tipsterEN = null;

        tipsterEN = _ITipsterCAD.GetTipsterById (id);
        return tipsterEN;
}

public System.Collections.Generic.IList<TipsterEN> GetAllTipsters (int first, int size)
{
        System.Collections.Generic.IList<TipsterEN> list = null;

        list = _ITipsterCAD.GetAllTipsters (first, size);
        return list;
}
public void AddFollow (int p_Tipster_OID, System.Collections.Generic.IList<int> p_follow_to_OIDs)
{
        //Call to TipsterCAD

        _ITipsterCAD.AddFollow (p_Tipster_OID, p_follow_to_OIDs);
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> GetFollows (int ? id)
{
        return _ITipsterCAD.GetFollows (id);
}
public void DeleteFollow (int p_Tipster_OID, System.Collections.Generic.IList<int> p_followed_by_OIDs)
{
        //Call to TipsterCAD

        _ITipsterCAD.DeleteFollow (p_Tipster_OID, p_followed_by_OIDs);
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> GetTipstersWithBenefit ()
{
        return _ITipsterCAD.GetTipstersWithBenefit ();
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> GetStatsByMonth (Nullable<DateTime> p_date, int ? p_oid)
{
        return _ITipsterCAD.GetStatsByMonth (p_date, p_oid);
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> GetTipstersPremium ()
{
        return _ITipsterCAD.GetTipstersPremium ();
}
public PickadosGenNHibernate.EN.Pickados.TipsterEN FindByUser (string alias)
{
        return _ITipsterCAD.FindByUser (alias);
}
public PickadosGenNHibernate.EN.Pickados.TipsterEN FindByMail (string email)
{
        return _ITipsterCAD.FindByMail (email);
}
public PickadosGenNHibernate.EN.Pickados.TipsterEN FindByNIF (string nif)
{
        return _ITipsterCAD.FindByNIF (nif);
}
}
}
