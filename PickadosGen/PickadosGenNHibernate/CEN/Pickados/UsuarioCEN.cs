

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
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public int NewUser (string p_alias, string p_email, String p_password, Nullable<DateTime> p_created_at, Nullable<DateTime> p_updated_at, string p_nif, bool p_admin)
{
        UsuarioEN usuarioEN = null;
        int oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Alias = p_alias;

        usuarioEN.Email = p_email;

        usuarioEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        usuarioEN.Created_at = p_created_at;

        usuarioEN.Updated_at = p_updated_at;

        usuarioEN.Nif = p_nif;

        usuarioEN.Admin = p_admin;

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.NewUser (usuarioEN);
        return oid;
}

public void ModifyUser (int p_Usuario_OID, string p_alias, string p_email, String p_password, Nullable<DateTime> p_created_at, Nullable<DateTime> p_updated_at, string p_nif, bool p_admin)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Id = p_Usuario_OID;
        usuarioEN.Alias = p_alias;
        usuarioEN.Email = p_email;
        usuarioEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        usuarioEN.Created_at = p_created_at;
        usuarioEN.Updated_at = p_updated_at;
        usuarioEN.Nif = p_nif;
        usuarioEN.Admin = p_admin;
        //Call to UsuarioCAD

        _IUsuarioCAD.ModifyUser (usuarioEN);
}

public void DeleteUser (int id
                        )
{
        _IUsuarioCAD.DeleteUser (id);
}

public UsuarioEN GetUserById (int id
                              )
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioCAD.GetUserById (id);
        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> GetAllUsers (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioCAD.GetAllUsers (first, size);
        return list;
}
public PickadosGenNHibernate.EN.Pickados.UsuarioEN FindByUser (string name)
{
        return _IUsuarioCAD.FindByUser (name);
}
}
}
