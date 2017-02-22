

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

public int NewAdmin (TimeSpan p_createdAt, TimeSpan p_modifiedAt, string p_alias, string p_email, String p_password)
{
        AdminEN adminEN = null;
        int oid;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.CreatedAt = p_createdAt;

        adminEN.ModifiedAt = p_modifiedAt;

        adminEN.Alias = p_alias;

        adminEN.Email = p_email;

        adminEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        //Call to AdminCAD

        oid = _IAdminCAD.NewAdmin (adminEN);
        return oid;
}

public void ModifyAdmin (int p_Admin_OID, TimeSpan p_createdAt, TimeSpan p_modifiedAt, string p_alias, string p_email, String p_password)
{
        AdminEN adminEN = null;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.Id = p_Admin_OID;
        adminEN.CreatedAt = p_createdAt;
        adminEN.ModifiedAt = p_modifiedAt;
        adminEN.Alias = p_alias;
        adminEN.Email = p_email;
        adminEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        //Call to AdminCAD

        _IAdminCAD.ModifyAdmin (adminEN);
}

public void DeleteAdmin (int id
                         )
{
        _IAdminCAD.DeleteAdmin (id);
}
}
}
