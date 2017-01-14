

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
 *      Definition of the class PremiumCEN
 *
 */
public partial class PremiumCEN
{
private IPremiumCAD _IPremiumCAD;

public PremiumCEN()
{
        this._IPremiumCAD = new PremiumCAD ();
}

public PremiumCEN(IPremiumCAD _IPremiumCAD)
{
        this._IPremiumCAD = _IPremiumCAD;
}

public IPremiumCAD get_IPremiumCAD ()
{
        return this._IPremiumCAD;
}

public int New_ (TimeSpan p_createdAt, TimeSpan p_modifiedAt, string p_alias, string p_email, String p_password, float p_subscription_fee)
{
        PremiumEN premiumEN = null;
        int oid;

        //Initialized PremiumEN
        premiumEN = new PremiumEN ();
        premiumEN.CreatedAt = p_createdAt;

        premiumEN.ModifiedAt = p_modifiedAt;

        premiumEN.Alias = p_alias;

        premiumEN.Email = p_email;

        premiumEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        premiumEN.Subscription_fee = p_subscription_fee;

        //Call to PremiumCAD

        oid = _IPremiumCAD.New_ (premiumEN);
        return oid;
}

public void Modify (int p_Premium_OID, TimeSpan p_createdAt, TimeSpan p_modifiedAt, string p_alias, string p_email, String p_password, float p_subscription_fee)
{
        PremiumEN premiumEN = null;

        //Initialized PremiumEN
        premiumEN = new PremiumEN ();
        premiumEN.Id = p_Premium_OID;
        premiumEN.CreatedAt = p_createdAt;
        premiumEN.ModifiedAt = p_modifiedAt;
        premiumEN.Alias = p_alias;
        premiumEN.Email = p_email;
        premiumEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        premiumEN.Subscription_fee = p_subscription_fee;
        //Call to PremiumCAD

        _IPremiumCAD.Modify (premiumEN);
}

public void Destroy (int id
                     )
{
        _IPremiumCAD.Destroy (id);
}
}
}
