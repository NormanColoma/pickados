

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
 *      Definition of the class AdminCEN
 *
 */
public partial class AdminCEN
{
private IAdminCAD _IAdminCAD;

public AdminCEN()
{
        this._IAdminCAD = new AdminCAD ();
}

public AdminCEN(IAdminCAD _IAdminCAD)
{
        this._IAdminCAD = _IAdminCAD;
}

public IAdminCAD get_IAdminCAD ()
{
        return this._IAdminCAD;
}

public int NewAdmin (string p_alias, string p_email, String p_password, Nullable<DateTime> p_created_at, Nullable<DateTime> p_updated_at, string p_nif, bool p_admin)
{
        AdminEN adminEN = null;
        int oid;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.Alias = p_alias;

        adminEN.Email = p_email;

        adminEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        adminEN.Created_at = p_created_at;

        adminEN.Updated_at = p_updated_at;

        adminEN.Nif = p_nif;

        adminEN.Admin = p_admin;

        //Call to AdminCAD

        oid = _IAdminCAD.NewAdmin (adminEN);
        return oid;
}

public void ModifyAdmin (int p_Admin_OID, string p_alias, string p_email, String p_password, Nullable<DateTime> p_created_at, Nullable<DateTime> p_updated_at, string p_nif, bool p_admin)
{
        AdminEN adminEN = null;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.Id = p_Admin_OID;
        adminEN.Alias = p_alias;
        adminEN.Email = p_email;
        adminEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        adminEN.Created_at = p_created_at;
        adminEN.Updated_at = p_updated_at;
        adminEN.Nif = p_nif;
        adminEN.Admin = p_admin;
        //Call to AdminCAD

        _IAdminCAD.ModifyAdmin (adminEN);
}

public void DeleteAdmin (int id
                         )
{
        _IAdminCAD.DeleteAdmin (id);
}

public AdminEN GetAdminById (int id
                             )
{
        AdminEN adminEN = null;

        adminEN = _IAdminCAD.GetAdminById (id);
        return adminEN;
}

public System.Collections.Generic.IList<AdminEN> GetAllAdmins (int first, int size)
{
        System.Collections.Generic.IList<AdminEN> list = null;

        list = _IAdminCAD.GetAllAdmins (first, size);
        return list;
}
}
}
